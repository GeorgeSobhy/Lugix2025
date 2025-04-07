using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;

namespace Lugx2025.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUserModel?> GetByIdAsync(int id);
        Task<IEnumerable<ApplicationUserModel>> GetAllAsync();
        Task<bool> AddAsync(ApplicationUserModel entity);
        Task<bool> UpdateAsync(ApplicationUserModel entity);
        Task<bool> DeleteAsync(ApplicationUserModel entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
