using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;

namespace Lugx2025.BusinessLogic.Services.Interfaces
{
    public interface ITagService
    {
        Task<TagModel?> GetByIdAsync(int id);
        Task<IEnumerable<TagModel>> GetAllAsync();
        Task<bool> AddAsync(TagModel entity);
        Task<bool> UpdateAsync(TagModel entity);
        Task<bool> DeleteAsync(TagModel entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
