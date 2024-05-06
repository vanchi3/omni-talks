using OmniTalks.Models.CategoryViewModels;

namespace OmniTalks.Contracs
{
	public interface ICategoryService
	{
		public Task Add(CategoryViewModel model);
		public Task<List<CategoryViewModel>> GetAll();
	}
}
