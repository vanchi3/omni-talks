using Microsoft.AspNetCore.Identity;

namespace OmniTalks.Models.Domein
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<CommentLike> CommentLikes { get; set; } = [];

        public List<UserConnection> UserConnections { get; set; } = [];

        public List<Comment> Comments { get; set; } = [];

        public List<Chat> SentedChat { get; set; } = [];

        public List<Chat> RecievedChat { get; set; } = [];

        public List<Post> Posts { get; set; } = [];

        // ako sh triesh useri taka ->
        //public bool IsDeleted{ get; set; }
    }
}
