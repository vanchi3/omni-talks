using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniTalks.Contracs;
using OmniTalks.Models.UserViewModels;

namespace OmniTalks.Controllers
{
	[Authorize]
	public class FollowController : BaseController
	{
		private IFollowSrvice _service;

		public FollowController(IFollowSrvice service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<IActionResult> Follow(FollowerViewModel model)
		{

			Guid currentUserId = new Guid(CurrentUserId);
			if (model.UserId == currentUserId)
			{
				return this.RedirectToAction("OtherProfile", "User");	
			}

			await _service.Add(model, currentUserId);
			return RedirectToAction("OtherProfile", "User", new { id = model.UserId });
		}
	}
}
