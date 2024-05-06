using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniTalks.Contracs;
using OmniTalks.Models.PostViewModel;

namespace OmniTalks.Controllers
{
	[Authorize]
	public class LikeController : BaseController
	{
		private readonly ILikeService _likeService;

		public LikeController(ILikeService likeService)
		{
			_likeService = likeService;
		}

		[HttpPost]
		public async Task<IActionResult> Like(PostLikeViewModel postLikeVM)
		{
			await this._likeService.Add(postLikeVM, CurrentUserId);
			return RedirectToAction("Index", "Home");
		}
	}
}
