using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OmniTalks.Contracs;
using OmniTalks.Models.CategoryViewModels;
using OmniTalks.Models.Domein;
using OmniTalks.Models.PostViewModel;
using OmniTalks.Services;

namespace OmniTalks.Controllers
{
	[Authorize]
	public class PostController : BaseController
	{
		private IPostService _postService;
		private UserManager<User> _userManager;
		private ICategoryService _catrgoryService;

		public PostController(IPostService postService, UserManager<User> userManager, ICategoryService catrgoryService)
		{
			_postService = postService;
			_userManager = userManager;
			_catrgoryService = catrgoryService;
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			PostViewModel model = new PostViewModel();
			model.Categories = await _catrgoryService.GetAll();
			this.ViewBag.CategoriesList = new SelectList(model.Categories, "CategoryId", "Name");
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> Add(PostViewModel model)
		{
			string currtentId = CurrentUserId;
			await this._postService.Add(model, currtentId);
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> Remove(Guid id)
		{
			var userId = new Guid(CurrentUserId);
			await this._postService.Remove(id, userId, IsAdmin);
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var userId = new Guid(CurrentUserId);
			PostViewModel model = await this._postService.GetById(id);
			if (!ModelState.IsValid)
			{
				return RedirectToAction($"Index", "Home");
			}
			if (model.UserId == userId || this.User.IsInRole("Admin"))
			{
				List<CategoryViewModel> categories = await _catrgoryService.GetAll();
				this.ViewBag.CategoriesList = new SelectList(categories, "Id", "Name");

				return View(model);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(PostViewModel model)
		{
			Guid userId = new Guid(CurrentUserId);
			await this._postService.Edit(model);

			return RedirectToAction("Index", "Home");
		}
	}
}
