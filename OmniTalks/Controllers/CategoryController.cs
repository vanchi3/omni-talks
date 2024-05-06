using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniTalks.Contracs;
using OmniTalks.Models.CategoryViewModels;

namespace OmniTalks.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CategoryController : BaseController
	{
		private ICategoryService _service;

		public CategoryController(ICategoryService service)
		{
			_service = service;
		}
		[HttpGet]
		public IActionResult Add()
		{
			CategoryViewModel model = new CategoryViewModel();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Add(CategoryViewModel model)
		{
			await _service.Add(model);
			return RedirectToAction("Index", "Home");
		}
	}
}
