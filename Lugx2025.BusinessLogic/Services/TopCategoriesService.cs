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
    public class TopCategoriesService : ITopCategoriesService
    {
        private readonly ITopCategoriesRepository _TopCategoriesRepository;
        private readonly IMapper _mapper;
        public TopCategoriesService(ITopCategoriesRepository TopCategoriesRepository, IMapper mapper)
        {
            _TopCategoriesRepository = TopCategoriesRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(TopCategoriesModel entity)=> await _TopCategoriesRepository.AddAsync(_mapper.Map<TopCategories>(entity));

        public async Task<bool> DeleteAsync(TopCategoriesModel entity) => await _TopCategoriesRepository.DeleteAsync(_mapper.Map<TopCategories>(entity));

        public async Task<bool> DeleteByIdAsync(int id) => await _TopCategoriesRepository.DeleteByIdAsync(id);

        public async Task<IEnumerable<TopCategoriesModel>> GetAllAsync() => _mapper.Map<List<TopCategoriesModel>>( await _TopCategoriesRepository.GetAllAsync());

        public async Task<TopCategoriesModel?> GetByIdAsync(int id) =>  _mapper.Map<TopCategoriesModel>( await _TopCategoriesRepository.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(TopCategoriesModel entity) => await _TopCategoriesRepository.UpdateAsync(_mapper.Map<TopCategories>(entity));
    }
}
