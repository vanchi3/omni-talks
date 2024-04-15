using OmniTalks.Models.PostViewModel;

namespace OmniTalks.Contracs
{
	public interface ILikeService
	{
		public Task Add(PostLikeViewModel model, string id);
	}
}
