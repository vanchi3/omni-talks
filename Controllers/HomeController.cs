using Microsoft.AspNetCore.Mvc;
using OmniTalks.Contracs;
using OmniTalks.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace OmniTalks.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IPostService _postService;
        public HomeController(ILogger<HomeController> logger,IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Username = UserName;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
