using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;

namespace Lugx2025.BusinessLogic.Services.Interfaces
{
    public interface IContactUsService
    {
        Task<GameModel?> GetByIdAsync(int id);
        Task<IEnumerable<GameModel>> GetAllAsync();
        Task<bool> AddAsync(GameModel entity);
        Task<bool> UpdateAsync(GameModel entity);
        Task<bool> DeleteAsync(GameModel entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
