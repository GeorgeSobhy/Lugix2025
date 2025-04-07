using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;

namespace Lugx2025.BusinessLogic.Services.Interfaces
{
    public interface IGenreService
    {
        Task<GenreModel?> GetByIdAsync(int id);
        Task<IEnumerable<GenreModel>> GetAllAsync();
        Task<bool> AddAsync(GenreModel entity);
        Task<bool> UpdateAsync(GenreModel entity);
        Task<bool> DeleteAsync(GenreModel entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
