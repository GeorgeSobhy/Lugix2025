
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lugx.Website.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly ITopCategoriesService _topCategoriesService;
        public GenreController(IGenreService genreService, ITopCategoriesService topCategoriesService)
        {
            _genreService = genreService;
            _topCategoriesService = topCategoriesService;
        }
        public async Task<IActionResult> Index()
        {
            List<GenreModel> genres =( await _genreService.GetAllAsync()).ToList();
            return View(genres);
        }
        public IActionResult AddNewGenre()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewGenre(GenreModel result)
        {
            if(!ModelState.IsValid) 
                return View(result);

            await _genreService.AddAsync(result);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> TopCategories()
        {
            List<TopCategoriesModel> topCategories = (await _topCategoriesService.GetAllAsync()).Take(5).ToList();
            return View(topCategories);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var genre = await _genreService.GetByIdAsync(Id);
            if (genre == null)
                return NotFound();

            return View(genre);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(GenreModel model)
        {
            if(!ModelState.IsValid)
                return View(model);
            
            await _genreService.UpdateAsync(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var genre = await _genreService.GetByIdAsync(Id);
            if (genre == null)
                return NotFound();
            await _genreService.DeleteByIdAsync(genre.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
