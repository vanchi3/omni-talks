using Microsoft.EntityFrameworkCore;
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

        public async Task Add(AddCommentViewModel model, string id)
        {
            Comment comment = new Comment()
            {
                Id = Guid.NewGuid(),
                Text = model.Text,
                PostId = model.PostId,
                UserId = new Guid(id),
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var comment = await _context.Comments
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

		public async Task AddLike(CommentLikeViewModel model, string userId)
		{
			bool conatins = await _context.CommentsLikes.AnyAsync(x => x.UserId.ToString() == userId && x.CommentId == model.CommentId);
			if (!conatins)
			{
				CommentLike like = new CommentLike()
				{
					CommentId = model.CommentId,
					UserId = new Guid(userId),
				};
				_context.CommentsLikes.Add(like);
			}
			else
			{
				RemoveLike(model, userId);
			}
			_context.SaveChanges();
		}
		public async Task RemoveLike(CommentLikeViewModel model, string userId)
		{
			var like = _context.CommentsLikes.Where(x => x.UserId.ToString() == userId && x.CommentId == model.CommentId).FirstOrDefault();
			_context.CommentsLikes.Remove(like);
			_context.SaveChanges();
		}

		public async Task Edit(CommentViewModel model)
		{
			Comment comment = await _context.Comments.FindAsync(model.Id);
			comment.Text = model.Text;

			await _context.SaveChangesAsync();
		}
	}
}
