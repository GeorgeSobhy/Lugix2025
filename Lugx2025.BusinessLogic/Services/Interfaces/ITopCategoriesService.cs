using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.ViewModels;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;

namespace Lugx2025.BusinessLogic.Services.Interfaces
{
    public interface ITopCategoriesService
    {
        Task<TopCategoriesModel?> GetByIdAsync(int id);
        Task<IEnumerable<TopCategoriesModel>> GetAllAsync();
        Task<bool> AddAsync(TopCategoriesModel entity);
        Task<bool> UpdateAsync(TopCategoriesModel entity);
        Task<bool> DeleteAsync(TopCategoriesModel entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
