using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.CategoryViewModels;
using OmniTalks.Models.Domein;

namespace OmniTalks.Services
{
	public class CategoryService : ICategoryService
	{

		private ApplicationDbContext _context;

		public CategoryService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Add(CategoryViewModel model)
		{
			Category category = new Category()
			{
				Id = new Guid(),
				Name = model.Name,
				Bio = model.Bio,
				Posts = model.Posts,
			};

			await _context.Categories.AddAsync(category);
			await _context.SaveChangesAsync();
		}

		public async Task<List<CategoryViewModel>> GetAll()
		{
			List<CategoryViewModel> categories = await _context.Categories.Select(x => new CategoryViewModel()
			{
				Id = x.Id,
				Name = x.Name,
				Bio = x.Bio

			}).ToListAsync();

			return categories;
		}
	}
}
