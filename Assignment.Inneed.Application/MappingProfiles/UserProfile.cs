using Assignment.Inneed.Application.Features.User.Commands.CreateUser;
using Assignment.Inneed.Application.Features.User.Queries.GetAllUsers;
using Assignment.Inneed.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Application.MappingProfiles;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<CreateUserCommand, User>();
    }
}
