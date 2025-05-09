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
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public GameRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAsync(Game entity)
        {

                await _dbContext.AddAsync(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;

        }

        public async Task<bool> DeleteAsync(Game entity)
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

        public async Task<ICollection<Game>> GetAllAsync(params Expression<Func<Game,object>>[] Includes)
        {
            var query = _dbContext.Games.AsQueryable();

            if(Includes != null)
            {
                query = Includes.Aggregate(query, (current, next) => current.Include(next));
            }
            return await query.ToListAsync();
        }


        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _dbContext.Games.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateAsync(Game entity)
        {
             _dbContext.Update(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
