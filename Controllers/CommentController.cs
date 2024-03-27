using Microsoft.AspNetCore.Mvc;
using OmniTalks.Contracs;
using OmniTalks.Models;
using System.ComponentModel.DataAnnotations;

namespace OmniTalks.Controllers
{
	public class CommentController : BaseController
	{
		private ICommentService _service;

		public CommentController(ICommentService servise)
		{
			this._service = servise;
		}

		//[HttpGet]
		//public async Task<IActionResult> Add()
		//{
		//	CommentViewModel model = new CommentViewModel();
		//	return View(model);
		//}
		[HttpPost]
		public async Task<IActionResult> Add(CommentViewModel model)
		{
			string currentId = CurrentUserId;
			await this._service.Add(model,currentId);
			return RedirectToAction("Index", "Home");
		}
	}
}
