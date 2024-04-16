using Microsoft.AspNetCore.Identity;
using System.Runtime;

namespace OmniTalks.Models.Domein
{
	public class User : IdentityUser<Guid>
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public List<CommentLike> CommentLikes { get; set; } = [];

		public List<Comment> Comments { get; set; } = [];

		public List<Chat> SentedChat { get; set; } = [];

		public List<Chat> RecievedChat { get; set; } = [];

		public List<Post> Posts { get; set; } = [];

		public List<Follow> Following { get; set; }

		public List<Follow> Followers { get; set; }

		//public string BackgroudPhotoUrl {  get; set; }

		public string ProfilePhtotoUrl { get; set; }
		// ako sh triesh useri taka ->
		//public bool IsDeleted{ get; set; }
	}
}
