using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
	public class Follow
	{
		[Key]
		public Guid Id { get; set; }

		public bool IsFollowing { get; set; }

		[ForeignKey(nameof(User))]

		public Guid UserId { get; set; }

		public User User { get; set; }

		[ForeignKey(nameof(Follower))]

		public Guid FollowerId { get; set; }

		public User Follower { get; set; }
	}
}
