using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag?> GetByIdAsync(int id);
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<bool> AddAsync(Tag entity);
        Task<bool> UpdateAsync(Tag entity);
        Task<bool> DeleteAsync(Tag entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
