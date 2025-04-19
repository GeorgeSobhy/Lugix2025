using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Lugx.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new MainPageVM()
            {
                MainPageDescription = "test",
                MainGameImage = "https://upload.wikimedia.org/wikipedia/en/5/52/Assassin%27s_Creed.jpg",
                Title = "test",
                GamePriceAfterDiscount = 100,
                GamePriceWithoutDiscount = 150,
                TrendingGames = new List<GameVM>(),
                MostPlayed = new List<GameVM>(),
                TopCategoriesGames = new List<GameVM>(),
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
