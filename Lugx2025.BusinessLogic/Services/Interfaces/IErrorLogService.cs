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
    public interface IErrorLogService
    {
        Task<ErrorLogModel?> GetByIdAsync(int id);
        Task<ICollection<ErrorLogModel>> GetAllAsync();
        Task<bool> AddAsync(ErrorLogModel entity);
        Task<bool> UpdateAsync(ErrorLogModel entity);
        Task<bool> DeleteAsync(ErrorLogModel entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
