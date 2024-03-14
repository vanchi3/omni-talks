using Microsoft.AspNetCore.Mvc;
using OmniTalks.Contracs;
using OmniTalks.Models;

namespace OmniTalks.Controllers
{
    public class LikeController : Controller
    {
        private ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> Like(PostLikeViewModel postLikeVM)
        {
            await this._likeService.Add(postLikeVM);
            return RedirectToAction("Index", "Home");
        }
    }
}
