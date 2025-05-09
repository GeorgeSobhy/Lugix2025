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
    public class ErrorLogService : IErrorLogService
    {
        private readonly IErrorLogRepository _ErrorLogRepository;
        private readonly IMapper _mapper;
        public ErrorLogService(IErrorLogRepository ErrorLogRepository, IMapper mapper)
        {
            _ErrorLogRepository = ErrorLogRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(ErrorLogModel entity)=> await _ErrorLogRepository.AddAsync(_mapper.Map<ErrorLog>(entity));

        public async Task<bool> DeleteAsync(ErrorLogModel entity) => await _ErrorLogRepository.DeleteAsync(_mapper.Map<ErrorLog>(entity));

        public async Task<bool> DeleteByIdAsync(int id) => await _ErrorLogRepository.DeleteByIdAsync(id);

        public async Task<ICollection<ErrorLogModel>> GetAllAsync() => _mapper.Map<List<ErrorLogModel>>( await _ErrorLogRepository.GetAllAsync());

        public async Task<ErrorLogModel?> GetByIdAsync(int id) =>  _mapper.Map<ErrorLogModel>( await _ErrorLogRepository.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(ErrorLogModel entity) => await _ErrorLogRepository.UpdateAsync(_mapper.Map<ErrorLog>(entity));
    }
}
