using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid RecieverUserId { get; set; }
        public User RecieverUser { get; set; }  
        public Guid SenderUserId { get; set; }
        public User SenderUser { get; set; }
        public string Text { get; set; }
    }
}
