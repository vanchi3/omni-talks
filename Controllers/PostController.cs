using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models;
using OmniTalks.Models.Domein;
using OmniTalks.Services;

namespace OmniTalks.Controllers
{
    public class PostController : BaseController
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            PostViewModel model = new PostViewModel();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(PostViewModel model)
        {
            string currtentId = CurrentUserId;
			await this._postService.Add(model, currtentId);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Remove(Guid id)
        {
            var userId = new Guid(CurrentUserId);
            await this._postService.Remove(id, userId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            var userId = new Guid(CurrentUserId);
            PostViewModel model = await this._postService.GetById(id);
			if (!ModelState.IsValid)
			{
				return RedirectToAction($"Index", "Home");
			}
			if (model.UserId == userId)
            {
				return View(model);
			}
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            Guid userId = new Guid(CurrentUserId);
            await this._postService.Edit(model);

            return RedirectToAction("Index", "Home");
        }
    }
}
