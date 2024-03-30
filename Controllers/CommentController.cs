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
			await this._service.Add(model, currentId);
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			Guid userId = new Guid(CurrentUserId);
			Guid commenterId = await this._service.GetById(id);
			if(commenterId == userId)
			{
				CommentViewModel model = await this._service.Rewrite(id);

				return View(model);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
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
			Guid userId = new Guid(CurrentUserId);
			await this._service.Remove(model.Id,userId);
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
