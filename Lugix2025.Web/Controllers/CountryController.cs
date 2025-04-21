using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services;
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
        public async Task<IActionResult> Index()
        {
            var Countries = (await _countryService.GetAllAsync()).ToList();
            return View(Countries);
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(CountryModel result)
        {
            if (!ModelState.IsValid)
                return View(result);

            await _countryService.AddAsync(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var Country = await _countryService.GetByIdAsync(Id);
            if (Country == null)
                return NotFound();

            return View(Country);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CountryModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _countryService.UpdateAsync(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var Country = await _countryService.GetByIdAsync(Id);
            if (Country == null)
                return NotFound();
            await _countryService.DeleteByIdAsync(Country.Id);

            return RedirectToAction(nameof(Index));
        }

    }
}
