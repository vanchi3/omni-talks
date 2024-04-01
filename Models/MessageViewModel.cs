using OmniTalks.Models.Domein;
using System.ComponentModel.DataAnnotations;

namespace OmniTalks.Models
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }
        public Guid RecieverUserId { get; set; }
        public User RecieverUser { get; set; } = null!;
        public Guid SenderUserId { get; set; }
        public User SenderUser { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
