using Lugx2025.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lugix2025.Web.Controllers
{
    public class AccountController : Controller
    {
        public async Task< IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(LoginVm vm)
        {
            if (!ModelState.IsValid)
                return View();
            
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
    }
}
