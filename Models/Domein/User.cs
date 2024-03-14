using Microsoft.AspNetCore.Identity;

namespace OmniTalks.Models.Domein
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CommentLike> CommentLikes { get; set; }
        public List<UserConnection> UserConnections { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Message> SentMessages { get; set; }
        public List<Message> RecievedMessages { get; set; }
        public List<Post> Posts { get; set; }
    }
}
