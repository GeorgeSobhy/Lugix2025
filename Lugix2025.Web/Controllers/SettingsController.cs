
using Lugx2025.Mapper.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Lugx.Website.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;
        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<IActionResult> Index()
        {
            var model =(await _settingsService.GetAllAsync()).FirstOrDefault();

            if( model == null)
                return NotFound();

            return View(model);
        }

        public IActionResult New()
        {
            return View();
        }
        public IActionResult New(SettingsModel model)
        {
            if(!ModelState.IsValid)
                return View(model);


            return RedirectToAction("index");
        }

    }
}
