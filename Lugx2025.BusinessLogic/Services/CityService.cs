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
    public class CityService : ICityService
    {
        private readonly ICityRepository _CityRepository;
        private readonly IMapper _mapper;
        public CityService(ICityRepository CityRepository, IMapper mapper)
        {
            _CityRepository = CityRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(CityModel entity)=> await _CityRepository.AddAsync(_mapper.Map<City>(entity));

        public async Task<bool> DeleteAsync(CityModel entity) => await _CityRepository.DeleteAsync(_mapper.Map<City>(entity));

        public async Task<bool> DeleteByIdAsync(int id) => await _CityRepository.DeleteByIdAsync(id);

        public async Task<IEnumerable<CityModel>> GetAllAsync() => _mapper.Map<List<CityModel>>( await _CityRepository.GetAllAsync());

        public async Task<CityModel?> GetByIdAsync(int id) =>  _mapper.Map<CityModel>( await _CityRepository.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(CityModel entity) => await _CityRepository.UpdateAsync(_mapper.Map<City>(entity));
    }
}
