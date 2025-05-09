using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Repository.Interfaces
{
    public interface INewsLetterRepository
    {
        Task<NewsLetter?> GetByIdAsync(int id);
        Task<ICollection<NewsLetter>> GetAllAsync(params Expression<Func<NewsLetter, object>>[] Includes);
        Task<bool> AddAsync(NewsLetter entity);
        Task<bool> UpdateAsync(NewsLetter entity);
        Task<bool> DeleteAsync(NewsLetter entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
