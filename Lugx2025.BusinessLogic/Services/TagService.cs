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
    public class TagService : ITagService
    {
        private readonly ITagRepository _TagRepository;
        private readonly IMapper _mapper;
        public TagService(ITagRepository TagRepository, IMapper mapper)
        {
            _TagRepository = TagRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(TagModel entity)=> await _TagRepository.AddAsync(_mapper.Map<Tag>(entity));

        public async Task<bool> DeleteAsync(TagModel entity) => await _TagRepository.DeleteAsync(_mapper.Map<Tag>(entity));

        public async Task<bool> DeleteByIdAsync(int id) => await _TagRepository.DeleteByIdAsync(id);

        public async Task<IEnumerable<TagModel>> GetAllAsync() => _mapper.Map<List<TagModel>>( await _TagRepository.GetAllAsync());

        public async Task<TagModel?> GetByIdAsync(int id) =>  _mapper.Map<TagModel>( await _TagRepository.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(TagModel entity) => await _TagRepository.UpdateAsync(_mapper.Map<Tag>(entity));
    }
}
