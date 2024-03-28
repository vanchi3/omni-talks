using OmniTalks.Models;

namespace OmniTalks.Contracs
{
	public interface ICommentService
	{
		public Task Add(AddCommentViewModel model, string id);
		public Task Remove(Guid id);
		public Task AddLike(CommentLikeViewModel model, string userId);
		public Task RemoveLike(CommentLikeViewModel model, string userId);
		public Task Edit(CommentViewModel model);
	}
}
