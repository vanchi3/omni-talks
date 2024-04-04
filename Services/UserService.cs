using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.Domein;

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
	}
}
