using Assignment.Inneed.Application.Contracts.Logging;
using Assignment.Inneed.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Application.Features.User.Queries.GetAllUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAppLogger<GetUsersQueryHandler> _logger;

        public GetUsersQueryHandler(IMapper mapper, IUserRepository userRepository, IAppLogger<GetUsersQueryHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            //query the database
            var users = await _userRepository.GetAsync();
            // convert data objects to dto objects
            var data = _mapper.Map<List<UserDto>>(users);

            //logging
            _logger.LogInformation("Users were retrieved successfully");
            //return list of dto objects
            return data;
        }
    }
}
