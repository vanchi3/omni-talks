using OmniTalks.Models.Domein;
using OmniTalks.Models.PostViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OmniTalks.Contracs
{
	public interface IPostService
	{
		public Task Add(PostViewModel model, string currentId);
		Task<List<PostViewModel>> All(Guid? userId = null);
		public Task Remove(Guid id, Guid userId, bool isAdmin);
		public Task Edit(PostViewModel model);
		//public Task<PostViewModel> Rewrite(Guid id);
		public Task<PostViewModel> GetById(Guid id);

	}
}
