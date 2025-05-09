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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _CountryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository CountryRepository, IMapper mapper)
        {
            _CountryRepository = CountryRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(CountryModel entity)=> await _CountryRepository.AddAsync(_mapper.Map<Country>(entity));

        public async Task<bool> DeleteAsync(CountryModel entity) => await _CountryRepository.DeleteAsync(_mapper.Map<Country>(entity));

        public async Task<bool> DeleteByIdAsync(int id) => await _CountryRepository.DeleteByIdAsync(id);

        public async Task<ICollection<CountryModel>> GetAllAsync() => _mapper.Map<List<CountryModel>>( await _CountryRepository.GetAllAsync());

        public async Task<CountryModel?> GetByIdAsync(int id) =>  _mapper.Map<CountryModel>( await _CountryRepository.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(CountryModel entity) => await _CountryRepository.UpdateAsync(_mapper.Map<Country>(entity));
    }
}
