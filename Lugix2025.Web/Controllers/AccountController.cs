using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Lugx2025.Mapper.Models;
using System.Diagnostics;
using Lugx2025.Mapper.ViewModels;
using Microsoft.AspNetCore.Identity;
using Lugx2025.Data.Entities;

namespace Lugix2025.Web.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(ILogger<AccountController> logger, IUserService userService, ICityService cityService, ICountryService countryService, IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userService = userService;
            _cityService = cityService;
            _countryService = countryService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [NonAction]
        private async Task Populate()
        {
            ViewBag.Cities = (await _cityService.GetAllAsync()).ToList();
            ViewBag.Countries = (await _countryService.GetAllAsync()).ToList();
        }
        [HttpGet("SignUp")]
        public async Task<IActionResult> SignUp()
        {
            await Populate();
            return View();
        }
        [HttpPost("SignUp")]
        
        public async Task<IActionResult> SignUp(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                await Populate();
                return View(model);
            }
            var newUser = _mapper.Map<ApplicationUser>(model);
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("CreateAccount", error.Description);
                await Populate();
                return View(model);
            }

            return RedirectToAction(nameof(Login));
        }
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginVm model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("login", "Email or password or both is wrong");
                return View(model);
            }
            var success = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!success)
            {
                ModelState.AddModelError("login", "Email or password or both is wrong");
                return View(model);
            }
            await _signInManager.SignInAsync(user, isPersistent: model.RememberMe);
            return RedirectToAction("Index", "Home");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
