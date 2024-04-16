using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OmniTalks.Contracs;
using OmniTalks.Models.PostViewModel;
using OmniTalks.Models.CategoryViewModels;
using OmniTalks.Services;

namespace OmniTalks.Controllers
{
    public class HomeController : BaseController
    {
        private IPostService _postService;
        private ICategoryService _categoryService;

        public HomeController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Username = UserName;
            ViewBag.CurrentUserId = new Guid(CurrentUserId);
            ViewBag.ProfilePhoto = UserProfilePhoto;

            List<CategoryViewModel> categories = await _categoryService.GetAll();
            this.ViewBag.CategoriesList = new SelectList(categories, "Id", "Name");

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
