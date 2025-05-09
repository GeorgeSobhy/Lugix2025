using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface IContactUsRepository
    {
        Task<ContactUs?> GetByIdAsync(int id);
        Task<ICollection<ContactUs>> GetAllAsync(params Expression<Func<ContactUs, object>>[] Includes);
        Task<bool> AddAsync(ContactUs entity);
        Task<bool> UpdateAsync(ContactUs entity);
        Task<bool> DeleteAsync(ContactUs entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
