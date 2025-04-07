using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;

namespace Lugx2025.BusinessLogic.Services.Interfaces
{
    public interface INewsLetterService
    {
        Task<NewsLetterModel?> GetByIdAsync(int id);
        Task<IEnumerable<NewsLetterModel>> GetAllAsync();
        Task<bool> AddAsync(NewsLetterModel entity);
        Task<bool> UpdateAsync(NewsLetterModel entity);
        Task<bool> DeleteAsync(NewsLetterModel entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
