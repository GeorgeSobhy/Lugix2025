
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lugx.Website.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult New()
        {
            return View();
        } 
        public async Task<IActionResult> New(CityModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            await _cityService.AddAsync(model);
            return RedirectToAction("Index");
        }

    }
}
