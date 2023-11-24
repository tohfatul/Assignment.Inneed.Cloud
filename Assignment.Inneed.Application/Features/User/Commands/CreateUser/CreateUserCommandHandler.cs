using Assignment.Inneed.Application.Contracts.Logging;
using Assignment.Inneed.Application.Contracts.Persistence;
using Assignment.Inneed.Application.Exceptions;
using Assignment.Inneed.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IAppLogger<CreateUserCommandHandler> _logger;

    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IRoleRepository roleRepository,
        IAppLogger<CreateUserCommandHandler> logger)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _logger = logger;
    }
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        //validate incomming data
        var role = await _roleRepository.GetRoleByRoleName(request.RoleName);

        if (role == null)
            throw new NotFoundException(request.RoleName, "Role Not Found");


        var validator = new CreateUserCommandValidator(_userRepository);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            _logger.LogWarning($"Validation errors in Save request for {0} - {1}", nameof(User), request.FullName);
            throw new BadRequestException("Invalid user", validationResult);
        }


        //convert to domain entity object
        //var userToCreate = _mapper.Map<Domain.User>(request);
        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);


        var userToCreate = new Domain.User
        {
            FullName = request.FullName,
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            RoleId = role.Id
        };
        //add to database
        await _userRepository.CreateAsync(userToCreate);
        //return record id
        return userToCreate.Id;
    }

    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {

        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
