using AutoMapper;
using Lugx2025.BusinessLogic.Const;
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Lugx2025.BusinessLogic.ViewModels;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
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
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(IUserRepository UserRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ICollection<ApplicationUserModel>> GetAllAsync() => _mapper.Map<List<ApplicationUserModel>>( await _UserRepository.GetAllAsync());

        public async Task<ApplicationUserModel?> GetByIdAsync(int id) =>  _mapper.Map<ApplicationUserModel>( await _UserRepository.GetByIdAsync(id));


        public async Task Register(RegisterModel model)
        {
            if (model == null)
                throw new Exception("Argument is null");

            ApplicationUser user = new ApplicationUser()
            {
                Address = model.Address,
                Email = model.Email,
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(",", result.Errors.Select(result => result.Description));
                throw new Exception(errors);
            }
            var roleResult = await _userManager.AddToRoleAsync(user, Constants.user);

            if(!roleResult.Succeeded)
            {
                var errors = string.Join(",", roleResult.Errors.Select(roleResult => roleResult.Description));
                throw new Exception(errors);
            }
        }

    }
}
