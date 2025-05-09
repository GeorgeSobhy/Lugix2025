using Lugx2025.Data.Context;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository
{
    public class NewsLetterRepository : INewsLetterRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public NewsLetterRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAsync(NewsLetter entity)
        {
            await _dbContext.AddAsync(entity);
            return await _dbContext.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteAsync(NewsLetter entity)
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

        public async Task<ICollection<NewsLetter>> GetAllAsync(params Expression<Func<NewsLetter, object>>[] Includes)
        {
            var query = _dbContext.NewsLetters.AsQueryable();

            if (Includes != null)
            {
                query = Includes.Aggregate(query, (current, next) => current.Include(next));
            }
            return await query.ToListAsync();
        }
        public async Task<NewsLetter?> GetByIdAsync(int id)
        {
            return await _dbContext.NewsLetters.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateAsync(NewsLetter entity)
        {
             _dbContext.Update(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
