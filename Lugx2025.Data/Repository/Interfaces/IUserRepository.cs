using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetByIdAsync(int id);
        Task<ICollection<ApplicationUser>> GetAllAsync(params Expression<Func<ApplicationUser, object>>[] Includes);
        Task<bool> AddAsync(ApplicationUser entity);
        Task<bool> UpdateAsync(ApplicationUser entity);
        Task<bool> DeleteAsync(ApplicationUser entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
