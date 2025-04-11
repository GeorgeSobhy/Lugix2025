using Microsoft.AspNetCore.Mvc;

namespace Lugix2025.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
