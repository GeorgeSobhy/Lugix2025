using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface ICityRepository
    {
        Task<bool> AddAsync(City entity);
        Task<bool> DeleteAsync(City entity);
        Task<bool> DeleteByIdAsync(int id);
        Task<IEnumerable<City>> GetAllAsync();
        Task<City?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(City entity);
    }
}
