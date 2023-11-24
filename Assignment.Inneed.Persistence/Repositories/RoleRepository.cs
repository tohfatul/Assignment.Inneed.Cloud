using Assignment.Inneed.Application.Contracts.Persistence;
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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AssignmentDatabaseContext context) : base(context)
        {
        }

        public async Task<Role> GetRoleByRoleName(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(q => q.RoleName == roleName);
        }
    }
}
