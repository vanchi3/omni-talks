using OmniTalks.Models.Domein;
using OmniTalks.Models.UserViewModels;

namespace OmniTalks.Contracs
{
	public interface IUserService
	{
		Task<User?> GetById(Guid id);
		public Task<bool> Conatins(Guid id, FollowerViewModel model);

    }
}