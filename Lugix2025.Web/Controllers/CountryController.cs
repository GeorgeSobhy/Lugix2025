using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lugx.Website.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult New()
        {
            return View();
        } 
        public IActionResult New(CountryModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            _countryService.AddAsync(model);
            return RedirectToAction("Index");
        }

    }
}
