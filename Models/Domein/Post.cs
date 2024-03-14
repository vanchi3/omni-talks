using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        //public string ImgUrl { get; set; }
        [ForeignKey(nameof(Domein.User))]
        public Guid UserId { get; set; }
        public User User{ get; set; }
        public List<PostLike>  PostLikes { get; set; }  
        public List<Comment> Comments { get; set; }  
    }
}
