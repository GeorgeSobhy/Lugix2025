using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface ICountryRepository
    {
        Task<bool> AddAsync(Country entity);
        Task<bool> DeleteAsync(Country entity);
        Task<bool> DeleteByIdAsync(int id);
        Task<ICollection<Country>> GetAllAsync(params Expression<Func<Country, object>>[] Includes);
        Task<Country?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Country entity);
    }
}
