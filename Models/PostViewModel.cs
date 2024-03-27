using OmniTalks.Models.Domein;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models
{
    public class PostViewModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }
        
        public string ImgUrl { get; set; }
        
        public Guid UserId { get; set; }
        
        public string UserName { get; set; }
        
        public List<PostLikeViewModel> PostLikes { get; set; }
        
        public List<CommentViewModel> Comments { get; set; }
    }
}
