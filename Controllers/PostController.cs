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
        private IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
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
            await this.postService.Add(model, currtentId);
			return RedirectToAction("Index", "Home");
		}
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Remove(Guid id)
        {
            await this.postService.Remove(id);
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		[Authorize]
		public IActionResult Edit()
		{
			PostViewModel model = new PostViewModel();

			return View(model);
		}
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Edit(PostViewModel model,Guid id)
		{
			string currtentId = CurrentUserId;
			await this.postService.Edit(model,id);
			return RedirectToAction("Index", "Home");
		}
	}
}
