using Assignment.Inneed.Application.Contracts.Persistence;
using Assignment.Inneed.Domain.Common;
using Assignment.Inneed.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AssignmentDatabaseContext _context;

        public GenericRepository(AssignmentDatabaseContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

       
        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        async Task<IReadOnlyList<T>> IGenericRepository<T>.GetAsync()
        {
            return await _context.Set<T> ().AsNoTracking().ToListAsync();
            
        }
    }
}
