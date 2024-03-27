using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public User User { get; set; } = null!;

        public List<PostLike> PostLikes { get; set; } = [];

        public List<Comment> Comments { get; set; } = [];

        //public string ImgUrl { get; set; }
    }
}
