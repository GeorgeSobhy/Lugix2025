using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag?> GetByIdAsync(int id);
        Task<ICollection<Tag>> GetAllAsync(params Expression<Func<Tag, object>>[] Includes);
        Task<bool> AddAsync(Tag entity);
        Task<bool> UpdateAsync(Tag entity);
        Task<bool> DeleteAsync(Tag entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
