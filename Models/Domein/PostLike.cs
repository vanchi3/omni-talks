using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
	public class PostLike
	{
		[Required]
		public Guid UserId { get; set; }
		public User User { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Post))]
		public Guid PostId { get; set; }
		public Post Post { get; set; } = null!;
    }
}
