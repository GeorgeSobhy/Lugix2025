﻿using AutoMapper;
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
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(GameModel entity)=> await _gameRepository.AddAsync(_mapper.Map<Game>(entity));

        public async Task<bool> DeleteAsync(GameModel entity) => await _gameRepository.DeleteAsync(_mapper.Map<Game>(entity));

        public async Task<bool> DeleteByIdAsync(int id) => await _gameRepository.DeleteByIdAsync(id);

        public async Task<ICollection<GameModel>> GetAllAsync() => _mapper.Map<List<GameModel>>( await _gameRepository.GetAllAsync());
        public async Task<ICollection<GameModel>> GetAllWithGenreAsync() => _mapper.Map<List<GameModel>>(await _gameRepository.GetAllAsync(game=>game.Genre));

        public async Task<GameModel?> GetByIdAsync(int id) =>  _mapper.Map<GameModel>( await _gameRepository.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(GameModel entity) => await _gameRepository.UpdateAsync(_mapper.Map<Game>(entity));
        public async Task<ICollection<GameModel>> GetTopGamesByCategory(int take, string genreCode)
        {
            var games = await GetAllAsync();
            return games.Where(g=>g.GenreCode == genreCode).ToList();
        }
        public async Task<GameModel> GetByGameCode(string gameCode) => _mapper.Map<GameModel>((await _gameRepository.GetAllAsync()).Where(g=>g.GameCode == gameCode).LastOrDefault());
    }
}
