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
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public GenreRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAsync(Genre entity)
        {
            await _dbContext.AddAsync(entity);
            return await _dbContext.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteAsync(Genre entity)
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

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await _dbContext.Genres.FirstOrDefaultAsync(g=>g.Id == id);
        }

        public async Task<bool> UpdateAsync(Genre entity)
        {
             _dbContext.Update(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
