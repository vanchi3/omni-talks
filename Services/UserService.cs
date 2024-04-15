using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.Domein;
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
	}
}
