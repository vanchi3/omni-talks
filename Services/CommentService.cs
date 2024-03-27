using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models;
using OmniTalks.Models.Domein;

namespace OmniTalks.Services
{
	public class CommentService : ICommentService
	{
		public ApplicationDbContext _context;

		public CommentService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task Add(CommentViewModel model, string id)
		{
			Guid userId = new Guid(id);
			Comment comment = new Comment()
			{
				Id = new Guid(),
				Text = model.Text,
				PostId = model.PostId,
				Post = await _context.Posts.FindAsync(model.PostId),
				UserId = new Guid(id),
				User = await _context.Users.FindAsync(userId),
				CommentLikes = new List<CommentLike>()
			};

			await _context.Comments.AddAsync(comment);
			await _context.SaveChangesAsync();

		}
	}
}
