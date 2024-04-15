using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.Domein;
using OmniTalks.Models.UserViewModels;

namespace OmniTalks.Services
{
	public class FollowService : IFollowSrvice
	{
		private ApplicationDbContext _context;

		public FollowService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Add(FollowerViewModel model, Guid userId)
		{
			if (model.IsFollowing == true)
			{
				await Remove(model, userId);
			}
			else
			{
				Follow follow = new Follow();
				follow.Id = Guid.NewGuid();
				follow.UserId = model.UserId;
				follow.FollowerId = userId;
				follow.IsFollowing = true;

				await _context.Following.AddAsync(follow);
				await _context.SaveChangesAsync();
			}
		}

		public async Task Remove(FollowerViewModel model, Guid userId)
		{
			Follow? follow = await _context.Following
				.FirstOrDefaultAsync(f => f.FollowerId == userId && model.UserId == f.UserId);

			if (follow == null)
			{
				throw new ArgumentNullException();
			}

			_context.Following.Remove(follow);
			await _context.SaveChangesAsync();
		}
	}
}
