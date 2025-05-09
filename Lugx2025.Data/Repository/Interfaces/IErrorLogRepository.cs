using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface IErrorLogRepository
    {
        Task<ErrorLog?> GetByIdAsync(int id);
        Task<ICollection<ErrorLog>> GetAllAsync(params Expression<Func<ErrorLog, object>>[] Includes);
        Task<bool> AddAsync(ErrorLog entity);
        Task<bool> UpdateAsync(ErrorLog entity);
        Task<bool> DeleteAsync(ErrorLog entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
