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
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _ContactUsRepository;
        private readonly IMapper _mapper;
        public ContactUsService(IContactUsRepository ContactUsRepository, IMapper mapper)
        {
            _ContactUsRepository = ContactUsRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(ContactUsModel entity)=> await _ContactUsRepository.AddAsync(_mapper.Map<ContactUs>(entity));

        public async Task<bool> DeleteAsync(ContactUsModel entity) => await _ContactUsRepository.DeleteAsync(_mapper.Map<ContactUs>(entity));

        public async Task<bool> DeleteByIdAsync(int id) => await _ContactUsRepository.DeleteByIdAsync(id);

        public async Task<IEnumerable<ContactUsModel>> GetAllAsync() => _mapper.Map<List<ContactUsModel>>( await _ContactUsRepository.GetAllAsync());

        public async Task<ContactUsModel?> GetByIdAsync(int id) =>  _mapper.Map<ContactUsModel>( await _ContactUsRepository.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(ContactUsModel entity) => await _ContactUsRepository.UpdateAsync(_mapper.Map<ContactUs>(entity));
    }
}
