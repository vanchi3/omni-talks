using OmniTalks.Models.Domein;

namespace OmniTalks.Models.UserViewModels
{
	public class FollowerViewModelcs
	{
		public Guid Id { get; set; }
		public Guid FollowerId { get; set; }

		public List<Follow> Following { get; set; }

		public List<Follow> Followers { get; set; }
	}
}
