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
		public async Task<IActionResult> Add(AddCommentViewModel model)
		{
			string currentId = CurrentUserId;
			await this._service.Add(model,currentId);
			return RedirectToAction("Index", "Home");
		}
		[HttpPost]
		public async Task<IActionResult> Edit(CommentViewModel model)
		{
			await this._service.Edit(model);
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		public async Task<IActionResult> _ShowComments()
		{
			List<CommentViewModel> vms = new List<CommentViewModel>();
			return View(vms);
		}

		[HttpPost]
		public async Task<IActionResult> Remove(CommentViewModel model)
		{
			await this._service.Remove(model.Id);
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> AddLike(CommentLikeViewModel model)
		{
			string id = CurrentUserId;
			await _service.AddLike(model, id);
			return RedirectToAction("Index", "Home");
		}
	}
}
