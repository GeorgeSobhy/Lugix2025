
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Lugx2025.BusinessLogic.ViewModels;
using Lugx2025.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lugx.Website.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGameService _gameService;
        public ProductController(IGameService gameService)
        {
            _gameService = gameService;
        }
        public IActionResult Index(String GameCode)
        {
            //var result = _gameService.QueryModel(g=>g.GameCode ==gameName);
            //return View(result);

            return View(new ProductDetailsVM()
            {
                Description = "best game ever",
                Name =  "game name",
                PhotoPath = "https://say.games/_next/image?url=https%3A%2F%2Fcatalog-backend.sgdn.io%2Fracinga%2Fvideo_poster_en__unD5helXowxu&w=3840&q=75",
                PriceAfterSale = 10,
                PriceBeforeSale = 15,
                GameCode = "ggc",
                ShortDescription = "oh my god",
                ReviewsNumber = 5,
                StarsCount  = 5,
                
            });

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddNewGame()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewGame(GameModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.UploaderId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)??"0");
            var result = await _gameService.AddAsync(model);
            return View();
        }
    }
}
