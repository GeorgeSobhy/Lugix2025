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
        public async Task<IActionResult> Index([FromQuery]string? SearchText)
        {
            ShopVM shopPageVM = new ShopVM();
            //shopPageVM.genre = _mapper.Map<List<GenreModel>>( (await _genreService.GetAllAsync()).Take(5));
            shopPageVM.AllPagesNumber= 10;
            shopPageVM.CurrentPageNumber = 1;
            
            if (string.IsNullOrEmpty(SearchText))
            {
                shopPageVM.Games = _mapper.Map<List<GameVM>>((await _gameService.GetAllAsync()).Take(5));
                return View(shopPageVM);
            }    

            SearchText = SearchText.ToLower();

             shopPageVM.Games = _mapper.Map<List<GameVM>>( (await _gameService.GetAllAsync()).Where(game => game.Name.ToLower().Contains(SearchText)));
            return View(shopPageVM);
        }
    }
}
