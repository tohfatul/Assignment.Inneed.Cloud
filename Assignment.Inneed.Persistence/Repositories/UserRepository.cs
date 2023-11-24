using Assignment.Inneed.Application.Contracts.Persistence;
using Assignment.Inneed.Application.Features.User.Commands.LoginUser;
using Assignment.Inneed.Domain;
using Assignment.Inneed.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AssignmentDatabaseContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users
                .Include(x=>x.Role)
                .FirstOrDefaultAsync(q=>q.Email==email);
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            return await _context.Users.AnyAsync(q => q.Email == email) == false;
        }
    }
}
