using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
	public class CommentLike
	{
		[Required]
		public Guid UserId { get; set; }
		public User User { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Comment))]
		public Guid CommentId { get; set; }
		public Comment Comment { get; set; } = null!;
	}
}
