using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
	public class Comment
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public string Text { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Post))]
		public Guid PostId { get; set; }

		public Post Post { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }

		public User User { get; set; } = null!;

		public List<CommentLike> CommentLikes { get; set; } = [];
	}
}
