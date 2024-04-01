using Microsoft.AspNetCore.Mvc;
using OmniTalks.Contracs;
using OmniTalks.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace OmniTalks.Controllers
{
    public class HomeController : BaseController
    {
        private IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Username = UserName;
            ViewBag.CurrentUserId = new Guid(CurrentUserId);
            List<PostViewModel> models = await this._postService.All();
            return View(models);
        }

        //[HttpPost]
        //public async Task<IActionResult> Like(PostLikeViewModel postLikeVM)
        //{
        //    await this._likeService.Add(postLikeVM);
        //    return RedirectToAction("Index", "Home");
        //}
        
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
