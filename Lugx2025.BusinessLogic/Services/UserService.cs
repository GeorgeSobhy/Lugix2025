using AutoMapper;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(ApplicationUserModel entity)=> await _UserRepository.AddAsync(_mapper.Map<ApplicationUser>(entity));

        public async Task<bool> DeleteAsync(ApplicationUserModel entity) => await _UserRepository.DeleteAsync(_mapper.Map<ApplicationUser>(entity));

        public async Task<bool> DeleteByIdAsync(int id) => await _UserRepository.DeleteByIdAsync(id);

        public async Task<IEnumerable<ApplicationUserModel>> GetAllAsync() => _mapper.Map<List<ApplicationUserModel>>( await _UserRepository.GetAllAsync());

        public async Task<ApplicationUserModel?> GetByIdAsync(int id) =>  _mapper.Map<ApplicationUserModel>( await _UserRepository.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(ApplicationUserModel entity) => await _UserRepository.UpdateAsync(_mapper.Map<ApplicationUser>(entity));
    }
}
