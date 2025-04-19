using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface ICountryRepository
    {
        Task<bool> AddAsync(Country entity);
        Task<bool> DeleteAsync(Country entity);
        Task<bool> DeleteByIdAsync(int id);
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Country entity);
    }
}
