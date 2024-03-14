using OmniTalks.Models.Domein;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models
{
    public class PostViewModel
    {
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<PostLike> PostLikes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
