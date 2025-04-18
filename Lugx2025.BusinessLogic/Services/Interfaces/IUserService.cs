using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lugx2025.BusinessLogic.Models;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;

namespace Lugx2025.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUserModel>> GetAllAsync();
        Task<ApplicationUserModel?> GetByIdAsync(int id);
        Task Register(RegisterModel model);
    }
}
