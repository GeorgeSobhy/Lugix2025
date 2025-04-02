using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface IGameRepository
    {
        Task<Game?> GetByIdAsync(int id);
        Task<IEnumerable<Game>> GetAllAsync();
        Task<bool> AddAsync(Game entity);
        Task<bool> UpdateAsync(Game entity);
        Task<bool> DeleteAsync(Game entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
