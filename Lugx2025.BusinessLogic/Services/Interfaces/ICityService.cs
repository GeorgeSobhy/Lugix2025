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
    public interface ICityService
    {
        Task<CityModel?> GetByIdAsync(int id);
        Task<IEnumerable<CityModel>> GetAllAsync();
        Task<bool> AddAsync(CityModel entity);
        Task<bool> UpdateAsync(CityModel entity);
        Task<bool> DeleteAsync(CityModel entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
