using OmniTalks.Models;

namespace OmniTalks.Contracs
{
	public interface ICommentService
	{
		public Task Add(CommentViewModel model, string id);
	}
}
