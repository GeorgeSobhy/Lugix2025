using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Lugx2025.BusinessLogic.Models;
using System.Diagnostics;
using Lugx2025.BusinessLogic.ViewModels;

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

        public AccountController(ILogger<AccountController> logger, IUserService userService, ICityService cityService, ICountryService countryService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _cityService = cityService;
            _countryService = countryService;
            _mapper = mapper;
        }
        [HttpGet("SignUp")]
        public IActionResult SignUp()
        {
            ViewBag.Cities = _cityService.GetAllAsync(); 
            ViewBag.Countries = _countryService.GetAllAsync(); 
            return View();
        }
        [HttpPost("SignUp")]
        
        public IActionResult SignUp(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cities = _cityService.GetAllAsync();
                ViewBag.Countries = _countryService.GetAllAsync();
                return View(model);
            }
            if(model.Password !=model.ReWritePassword)
            {
                ModelState.AddModelError("matchPassword", "Password & Rewriting password should be the same");
                return View(model);
            }
            var newUser = _mapper.Map<ApplicationUserModel>(model);
            //newUser.CreationDate = DateTime.Now;
            //newUser.Active = true;
            //newUser.RoleId = 3;
            //_userService.Register(newUser);

            return RedirectToAction(nameof(Login));
        }
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginVm model)
        {
            
            return RedirectToAction("Index", "Home");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
