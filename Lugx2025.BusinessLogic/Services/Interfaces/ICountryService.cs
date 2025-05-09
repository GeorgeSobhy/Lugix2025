using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lugx2025.BusinessLogic.Models;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;

namespace Lugx2025.BusinessLogic.Services.Interfaces
{
    public interface ICountryService
    {
        Task<CountryModel?> GetByIdAsync(int id);
        Task<ICollection<CountryModel>> GetAllAsync();
        Task<bool> AddAsync(CountryModel entity);
        Task<bool> UpdateAsync(CountryModel entity);
        Task<bool> DeleteAsync(CountryModel entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
