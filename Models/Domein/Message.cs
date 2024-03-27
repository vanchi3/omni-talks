using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RecieverUserId { get; set; }
        public User RecieverUser { get; set; } = null!;

        [Required]
        public Guid SenderUserId { get; set; }
        public User SenderUser { get; set; } = null!;

        [Required]
        public string Text { get; set; } = null!;
    }
}
