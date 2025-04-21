
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services;
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
        public async Task< IActionResult> Index()
        {
            var cities = ( await _cityService.GetAllAsync()).ToList();
            return View(cities);
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(CityModel result)
        {
            if (!ModelState.IsValid)
                return View(result);

            await _cityService.AddAsync(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var City = await _cityService.GetByIdAsync(Id);
            if (City == null)
                return NotFound();

            return View(City);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CityModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _cityService.UpdateAsync(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var City = await _cityService.GetByIdAsync(Id);
            if (City == null)
                return NotFound();
            await _cityService.DeleteByIdAsync(City.Id);

            return RedirectToAction(nameof(Index));
        }

    }

    }
