using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre?> GetByIdAsync(int id);
        Task<ICollection<Genre>> GetAllAsync(params Expression<Func<Genre, object>>[] Includes);
        Task<bool> AddAsync(Genre entity);
        Task<bool> UpdateAsync(Genre entity);
        Task<bool> DeleteAsync(Genre entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
