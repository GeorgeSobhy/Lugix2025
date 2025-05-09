using AutoMapper;
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.BusinessLogic.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _SettingsRepository;
        private readonly IMapper _mapper;
        public SettingsService(ISettingsRepository SettingsRepository, IMapper mapper)
        {
            _SettingsRepository = SettingsRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(SettingsModel entity)=> await _SettingsRepository.AddAsync(_mapper.Map<Settings>(entity));

        public async Task<bool> DeleteAsync(SettingsModel entity) => await _SettingsRepository.DeleteAsync(_mapper.Map<Settings>(entity));

        public async Task<bool> DeleteByIdAsync(int id) => await _SettingsRepository.DeleteByIdAsync(id);

        public async Task<ICollection<SettingsModel>> GetAllAsync() => _mapper.Map<List<SettingsModel>>( await _SettingsRepository.GetAllAsync());

        public async Task<SettingsModel?> GetByIdAsync(int id) =>  _mapper.Map<SettingsModel>( await _SettingsRepository.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(SettingsModel entity) => await _SettingsRepository.UpdateAsync(_mapper.Map<Settings>(entity));
    }
}
