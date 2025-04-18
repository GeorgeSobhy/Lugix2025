using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Lugx2025.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lugix2025.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAllAsync();
            return View();
        }
        public async Task<IActionResult> GetById(int? Id)
        {
            if (Id == null || Id < 1)
                return NotFound();

            var game = await _gameService.GetByIdAsync(Id.Value);
            return View(game);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        public async Task<IActionResult> Add(GameModel game)
        {
            if(!ModelState.IsValid)
                return View(game);
            var result = await _gameService.AddAsync(game);

            if (result == false)
            {
                ModelState.AddModelError("fails", "The game didn't been saved due to an error");
                return View(game);
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? Id)
        {
            if(Id == null || Id<1)
                return NotFound();

           var game =  await _gameService.GetByIdAsync(Id.Value);
            return View(game);
        }

        public async Task<IActionResult> Edit(GameModel game)
        {
            if (!ModelState.IsValid)
                return View(game);

            var result = await _gameService.UpdateAsync(game);


            if (result == false)
            {
                ModelState.AddModelError("fails", "The game didn't been saved due to an error");
                return View(game);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 1)
                return NotFound();

            var game = await _gameService.DeleteByIdAsync(Id.Value);
            return RedirectToAction("Index");
        }
    }
}
