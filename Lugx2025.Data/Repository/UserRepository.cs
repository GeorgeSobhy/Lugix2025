using Lugx2025.Data.Context;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public UserRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAsync(ApplicationUser entity)
        {
            await _dbContext.AddAsync(entity);
            return await _dbContext.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteAsync(ApplicationUser entity)
        {
             _dbContext.Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
                return false;

            _dbContext.Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<ApplicationUser?> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateAsync(ApplicationUser entity)
        {
             _dbContext.Update(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
