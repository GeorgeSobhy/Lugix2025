using AutoMapper;
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Lugx2025.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lugx.Website.Controllers
{
    public class ContactUsController : Controller
    {
        public ISettingsService _settingsService;
        public IContactUsService _contactUsService;
        public IGameService _gameService;
        public IMapper _mapper;
        public ContactUsController(ISettingsService settingsService, IContactUsService contactUsService, IMapper mapper, IGameService gameService)
        {
            _settingsService = settingsService;
            _contactUsService = contactUsService;
            _mapper = mapper;
            _gameService = gameService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var setting = (await _settingsService.GetAllAsync()).LastOrDefault();
            if(! (setting == null))
                return View(_mapper.Map<ContactUsPageVM>(setting));


            var newSettings = (await _settingsService.GetAllAsync()).LastOrDefault();
            if (newSettings == null)
                return RedirectToAction("Index", "dashboard");
            await _settingsService.AddAsync(newSettings);
            
            return View(_mapper.Map<ContactUsPageVM>(newSettings));
        }
        [HttpPost]
        public IActionResult SendMessage(ContactUsModel model)
        {
            if (!ModelState.IsValid)
            {
                // add contact us vm
                return View("index", model);
            }
            _contactUsService.AddAsync(model);
            return View("index");

        }
        
    }
}
