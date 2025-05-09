using AutoMapper;
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Lugx2025.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lugx.Website.Controllers
{
    public class ShopController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        public ShopController(IGameService gameService, IMapper mapper, IGenreService genreService)
        {
            _gameService = gameService;
            _mapper = mapper;
            _genreService = genreService;
        }
        public async Task<IActionResult> Index([FromQuery]string? SearchText, int Id = 1)
        {
            ShopVM shopPageVM = new ShopVM();

            var allGames = (await _gameService.GetAllWithGenreAsync());

            var allPagesCount = (int)Math.Ceiling(allGames.Count / 12.0);


            if (Id < 1 || Id > allPagesCount)
                Id = 1;

            // Set pagination properties
            shopPageVM.AllPagesNumber = allPagesCount;
            shopPageVM.Genres = (await _genreService.GetAllAsync()).OrderBy(g => g.Name).Take(6).ToList();
            shopPageVM.CurrentPageNumber = Id;
            if (string.IsNullOrEmpty(SearchText))
            {
                // Implement proper pagination instead of just taking 5
                shopPageVM.Games = _mapper.Map<List<GameVM>>(allGames)
                     .Skip((Id - 1) * 12)
                     .Take(12)
                     .ToList();
            }
            else
            {
                // Add search functionality
                shopPageVM.Games = _mapper.Map<List<GameVM>>(allGames)
                    .Where(g => g.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                    .Skip((Id - 1) * 12)
                    .Take(12)
                    .ToList();
            }

            return View(shopPageVM);
        }
    }
}
