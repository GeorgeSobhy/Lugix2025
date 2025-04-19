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
    public interface IContactUsService
    {
        Task<ContactUsModel?> GetByIdAsync(int id);
        Task<IEnumerable<ContactUsModel>> GetAllAsync();
        Task<bool> AddAsync(ContactUsModel entity);
        Task<bool> UpdateAsync(ContactUsModel entity);
        Task<bool> DeleteAsync(ContactUsModel entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
