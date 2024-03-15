using Microsoft.AspNetCore.Mvc;
using OmniTalks.Contracs;
using OmniTalks.Models;

namespace OmniTalks.Controllers
{
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
            await this._likeService.Add(postLikeVM,CurrentUserId);
            return RedirectToAction("Index", "Home");
        }
    }
}
