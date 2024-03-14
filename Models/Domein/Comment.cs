using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
	public class Comment
	{

		public Guid Id { get; set; }
		[Required] 
		public string Text { get; set; }
		public Guid PostId { get; set; }
        public Post Post { get; set; }

        [ForeignKey(nameof(Domein.User))]
		public Guid UserId { get; set; }
        public User User { get; set; }

        public List<CommentLike> CommentLikes { get; set; }
	
	}
}
