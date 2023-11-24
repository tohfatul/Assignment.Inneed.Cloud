using Assignment.Inneed.Application.Contracts.Jwt;
using Assignment.Inneed.Application.Contracts.Persistence;
using Assignment.Inneed.Application.Exceptions;
using Assignment.Inneed.Application.Features.User.Commands.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Application.Features.User.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginUserCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<LoginResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            
            if(user == null)
                throw new NotFoundException(request.Email);

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                throw new BadRequestException("Invalid User/ Password!");


            return new LoginResponseDto
            {
                Email = user.Email,
                FullName = user.FullName,
                Token = _jwtTokenGenerator.GenerateToken(user)
            };

        }


        //helper methods

        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt) //protection level was private but made it public to use from other class
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;

        }
    }
}
