using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OmniTalks.Contracs;
using OmniTalks.Models.PostViewModel;
using OmniTalks.Models.CategoryViewModels;
using OmniTalks.Services;
using OmniTalks.Models.UserViewModels;
using System.Collections.Generic;

namespace OmniTalks.Controllers
{
    public class HomeController : BaseController
    {
        private IPostService _postService;
        private ICategoryService _categoryService;
        private IUserService _userService;

        public HomeController(IPostService postService, ICategoryService categoryService, IUserService userService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _userService = userService;
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
            List<UserViewModel> friends = await this._userService.Friends(new Guid(CurrentUserId));
			this.ViewBag.FriendsList = new SelectList(friends, "Id", "Name", "ProfilePhotoUrl");

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
