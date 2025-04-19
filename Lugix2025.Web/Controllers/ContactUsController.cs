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
        public ContactUsController(ISettingsService settingsService, IContactUsService contactUsService)
        {
            _settingsService = settingsService;
            _contactUsService = contactUsService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ContactUsPageVM model = new ContactUsPageVM();//_settingsService.QueryFirstModel();

            model.ContactUsAddress = "downtown";
            model.ContactUsphone = "+1234343433";
            model.ContactUsEmail = "test@test.com";
            model.ContactUsDescription = "Description";
            
            return View(model);
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
