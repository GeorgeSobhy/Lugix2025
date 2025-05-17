using AutoMapper;
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Lugx2025.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Lugx.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISettingsService _settingsService;
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, ISettingsService settingsService, IGameService gameService, IMapper mapper)
        {
            _logger = logger;
            _settingsService = settingsService;
            _gameService = gameService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = new MainPageVM();
            //{
            //    MainPageDescription = "test",
            //    MainGameImage = "https://upload.wikimedia.org/wikipedia/en/5/52/Assassin%27s_Creed.jpg",
            //    Title = "test",
            //    GamePriceAfterDiscount = 100,
            //    GamePriceWithoutDiscount = 150,
            //    TrendingGames = new List<GameVM>(),
            //    MostPlayed = new List<GameVM>(),
            //    TopCategoriesGames = new List<GameVM>(),
            //};

            var settings = (await _settingsService.GetAllAsync()).FirstOrDefault();
            if (settings == null)
                return NotFound();

            var mainGame = (await _gameService.GetByIdAsync(settings.MainGameId));
            if (mainGame == null)
                return NotFound();

            model.Title = settings.MainPageHeader;
            model.MostPlayed =_mapper.Map<List<GameVM>>(await _gameService.GetAllAsync()).Take(6).ToList();
            model.TrendingGames= _mapper.Map<List<GameVM>>(await _gameService.GetAllAsync()).Take(6).ToList();
            model.MainPageDescription = settings.MainPageHeader;
            model.MainGameImage = mainGame!.PhotoPath;
            model.GamePriceWithoutDiscount = mainGame!.PriceBeforeSale;
            model.GamePriceAfterDiscount = mainGame.PriceAfterSale;
            model.TopCategoriesGames = _mapper.Map<List<GameVM>>(await _gameService.GetAllWithGenreAsync()).Take(6).ToList();

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
