using System.ComponentModel.DataAnnotations;

namespace OmniTalks.Models
{
    public class AddCommentViewModel
    {
        [Required]
        public Guid PostId { get; set; }

        [Required]
        public string Text { get; set; } = null!;
    }
}
