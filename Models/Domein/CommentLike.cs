using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
	public class CommentLike
	{
		public Guid Id { get; set; }
		
		[ForeignKey(nameof(Domein.User))]
		public Guid UserId { get; set; }
        public User User { get; set; }

		public Guid CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
