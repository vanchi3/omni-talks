using OmniTalks.Models.Domein;

namespace OmniTalks.Models.UserViewModels
{
	public interface FollowViewModel
	{
		public bool IsFollowing { get; set; }

		public Guid UserId { get; set; }

		public User User { get; set; }

		public Guid FollowerId { get; set; }

		public User Follower { get; set; }
	}
}
