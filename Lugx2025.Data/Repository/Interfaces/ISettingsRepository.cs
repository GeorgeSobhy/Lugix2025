using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface ISettingsRepository
    {
        Task<Settings?> GetByIdAsync(int id);
        Task<ICollection<Settings>> GetAllAsync(params Expression<Func<Settings, object>>[] Includes);
        Task<bool> AddAsync(Settings entity);
        Task<bool> UpdateAsync(Settings entity);
        Task<bool> DeleteAsync(Settings entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
