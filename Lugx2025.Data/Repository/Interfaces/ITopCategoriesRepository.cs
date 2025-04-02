using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface ITopCategoriesRepository
    {
        Task<TopCategories?> GetByIdAsync(int id);
        Task<IEnumerable<TopCategories>> GetAllAsync();
        Task<bool> AddAsync(TopCategories entity);
        Task<bool> UpdateAsync(TopCategories entity);
        Task<bool> DeleteAsync(TopCategories entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
