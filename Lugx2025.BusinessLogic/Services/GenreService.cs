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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _GenreRepository;
        private readonly IMapper _mapper;
        public GenreService(IGenreRepository GenreRepository, IMapper mapper)
        {
            _GenreRepository = GenreRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(GenreModel entity)=> await _GenreRepository.AddAsync(_mapper.Map<Genre>(entity));

        public async Task<bool> DeleteAsync(GenreModel entity) => await _GenreRepository.DeleteAsync(_mapper.Map<Genre>(entity));

        public async Task<bool> DeleteByIdAsync(int id) => await _GenreRepository.DeleteByIdAsync(id);

        public async Task<ICollection<GenreModel>> GetAllAsync() => _mapper.Map<List<GenreModel>>( await _GenreRepository.GetAllAsync());

        public async Task<GenreModel?> GetByIdAsync(int id) =>  _mapper.Map<GenreModel>( await _GenreRepository.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(GenreModel entity) => await _GenreRepository.UpdateAsync(_mapper.Map<Genre>(entity));
    }
}
