using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.Domein;
using OmniTalks.Models.PostViewModel;

namespace OmniTalks.Services
{
	public class LikePostService : ILikeService
	{
		public ApplicationDbContext _context;

		public LikePostService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task Add(PostLikeViewModel model, string userId)
		{

			bool conatins = await _context.PostsLikes.AnyAsync(x => x.UserId.ToString() == userId && x.PostId == model.PostId);
			if (!conatins)
			{
				PostLike like = new PostLike()
				{
					PostId = model.PostId,
					UserId = new Guid(userId),
				};
				_context.PostsLikes.Add(like);
			}
			else
			{
				Remove(model, userId);
			}
			_context.SaveChanges();
		}

		public async Task Remove(PostLikeViewModel model, string userId)
		{
			var like = _context.PostsLikes.Where(x => x.UserId.ToString() == userId && x.PostId == model.PostId).FirstOrDefault();
			_context.PostsLikes.Remove(like);
			_context.SaveChanges();
		}
	}
}
