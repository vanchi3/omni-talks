using OmniTalks.Models.UserViewModels;

namespace OmniTalks.Contracs
{
	public interface IFollowService
	{
		public Task Add(FollowerViewModel model, Guid userId);
		public Task Remove(FollowerViewModel model, Guid userId);
	}
}
