﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lugx2025.BusinessLogic.Models;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;

namespace Lugx2025.BusinessLogic.Services.Interfaces
{
    public interface ISettingsService
    {
        Task<SettingsModel?> GetByIdAsync(int id);
        Task<ICollection<SettingsModel>> GetAllAsync();
        Task<bool> AddAsync(SettingsModel entity);
        Task<bool> UpdateAsync(SettingsModel entity);
        Task<bool> DeleteAsync(SettingsModel entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}
