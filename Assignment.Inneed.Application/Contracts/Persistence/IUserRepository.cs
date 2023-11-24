using Assignment.Inneed.Application.Features.User.Commands.LoginUser;
using Assignment.Inneed.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    Task<bool> IsEmailUnique(string email);
    Task<User> GetUserByEmail(string email);
}
