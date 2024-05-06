
using OmniTalks.Models.CommentViewModels;

namespace OmniTalks.Contracs
{
	public interface ICommentService
	{
		public Task Add(AddCommentViewModel model, string id);
		public Task Remove(Guid id, Guid userId);
		public Task AddLike(CommentLikeViewModel model, string userId);
		public Task RemoveLike(CommentLikeViewModel model, string userId);
		public Task Edit(CommentViewModel model);
		public Task<CommentViewModel> Rewrite(Guid id);
		public Task<Guid> GetById(Guid id);
	}
}
