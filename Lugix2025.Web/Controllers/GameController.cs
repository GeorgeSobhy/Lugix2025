using AutoMapper;
using Lugx2025.Mapper.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Lugx2025.Mapper.ViewModels;
using Lugx2025.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lugix2025.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        public GameController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }
        [Authorize]
        
        public async Task<IActionResult> Index()
        {
            var Games = _mapper.Map<List<GameVM>>(await _gameService.GetAllAsync());
            return View(Games);
        }
        [Route("game/{Id:int}")]
        public async Task<IActionResult> GetById(int? Id)
        {
            if (Id == null || Id < 1)
                return NotFound();

            var game = await _gameService.GetByIdAsync(Id.Value);
            if (game == null)
                return NotFound();
            return View(game);
        }
        [Route("game/{gameCode:alpha}")]
        public async Task<IActionResult> GetById(string gameCode)
        {
            if (string.IsNullOrEmpty(gameCode))
                return NotFound();

            var game = await _gameService.GetByGameCode(gameCode);
            if (game == null)
                return NotFound();
            return View(game);
        }
        [Authorize]
        [Route("Game/Add")]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [Authorize]
        [HttpPost("Game/Add")]
        public async Task<IActionResult> Add(GameModel game)
        {
            if(!ModelState.IsValid)
                return View(game);
            game.UploaderId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

            var result = await _gameService.AddAsync(game);

            if (result == false)
            {
                ModelState.AddModelError("fails", "The game didn't been saved due to an error");
                return View(game);
            }

            return RedirectToAction("Index");
        }
        [Authorize]
        [Route("Game/Edit/{Id:int}")]
        public async Task<IActionResult> Edit(int? Id)
        {
            if(Id == null || Id<1)
                return NotFound();

           var game =  await _gameService.GetByIdAsync(Id.Value);
            if(game == null)
                return NotFound();
            return View(game);
        }
        [Authorize]
        [HttpPost("Game/Edit")]
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
        [Authorize]
        [Route("game/delete/{Id:int}")]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null || Id < 1)
                return NotFound();

            var game = await _gameService.DeleteByIdAsync(Id.Value);
            return RedirectToAction("Index");
        }
    }
}
