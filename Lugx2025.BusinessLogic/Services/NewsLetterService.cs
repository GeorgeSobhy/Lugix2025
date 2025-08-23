using AutoMapper;
using Lugx2025.Mapper.Models;
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
    public class NewsLetterService : INewsLetterService
    {
        private readonly INewsLetterRepository _NewsLetterRepository;
        private readonly IMapper _mapper;
        public NewsLetterService(INewsLetterRepository NewsLetterRepository, IMapper mapper)
        {
            _NewsLetterRepository = NewsLetterRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(NewsLetterModel entity)=> await _NewsLetterRepository.AddAsync(_mapper.Map<NewsLetter>(entity));

        public async Task<bool> DeleteAsync(NewsLetterModel entity) => await _NewsLetterRepository.DeleteAsync(_mapper.Map<NewsLetter>(entity));

        public async Task<bool> DeleteByIdAsync(int id) => await _NewsLetterRepository.DeleteByIdAsync(id);

        public async Task<ICollection<NewsLetterModel>> GetAllAsync() => _mapper.Map<List<NewsLetterModel>>( await _NewsLetterRepository.GetAllAsync());

        public async Task<NewsLetterModel?> GetByIdAsync(int id) =>  _mapper.Map<NewsLetterModel>( await _NewsLetterRepository.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(NewsLetterModel entity) => await _NewsLetterRepository.UpdateAsync(_mapper.Map<NewsLetter>(entity));
    }
}
