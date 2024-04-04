using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; } = null!;
        
        [Required]
        public DateTime SentTime { get; set; }

        [ForeignKey(nameof(Chat))]
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; } = null!;

        [Required]
        public bool IsFromUser1 { get; set; }
    }
}
