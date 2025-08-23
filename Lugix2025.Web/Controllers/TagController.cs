
using Lugx2025.Mapper.Models;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lugix2025.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        public async Task<IActionResult> Index()
        {
            List<TagModel> tags = (await _tagService.GetAllAsync()).ToList() ;
            return View(tags);
        }
        public IActionResult AddNewTag()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewTag(TagModel result)
        {
            if(!ModelState.IsValid) 
                return View(result);

            await _tagService.AddAsync(result);
            return RedirectToAction("Index");
        }

    
    }
}
