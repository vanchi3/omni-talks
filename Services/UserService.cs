using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.Domein;
using OmniTalks.Models.PostViewModel;
using OmniTalks.Models.UserViewModels;

namespace OmniTalks.Services
{
	public class UserService : IUserService
	{
		private ApplicationDbContext _context;

		public UserService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<User?> GetById(Guid id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task<bool> Conatins(Guid id, FollowerViewModel model)
		{
			bool contains = await _context.Following?.AnyAsync(x => x.UserId == id && x.FollowerId == model.FollowerId);
			if (contains)
			{
				model.IsFollowing = true;
			}
			else
			{
				model.IsFollowing = false;
			}
			return contains;
		}

		public async Task<FollowerViewModel> FollowerAndFollowingDistribution(Guid currentUserId,Guid id, List<PostViewModel> models)
		{
			FollowerViewModel model = new FollowerViewModel
			{
				FollowerId = currentUserId,
				UserId = id,
				Following = await _context.Following
					.Include(f => f.User)
					.Where(f => f.FollowerId == id)
					.ToListAsync(),
				Followers = await this._context.Following
					.Include(f => f.Follower)
					.Where(f => f.UserId == id)
					.ToListAsync(),
				User = await _context.Users
					.Where(x => x.Id == id)
					.Select(u => new UserViewModel()
					{
						UserName = u.UserName,
						ProfilePhotoUrl = u.ProfilePhtotoUrl
					}).FirstOrDefaultAsync(),
				MyPosts = models
			};

			return model;
		}
	}
}
