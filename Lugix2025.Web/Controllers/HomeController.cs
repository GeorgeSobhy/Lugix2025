using System.Diagnostics;
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lugix2025.Web.Controllers
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
                GamePriceAfterDiscount = 0,
                GamePriceWithoutDiscount = 0,
                MainGameImage = "",
                MainPageDescription = ""


            };

            return View(model);
        }

        public IActionResult Privacy()
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
