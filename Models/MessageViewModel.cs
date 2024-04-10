using OmniTalks.Models.Domein;
using System.ComponentModel.DataAnnotations;

namespace OmniTalks.Models
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Text { get; set; } = null!;
		
        public Guid User1Id { get; set; }
		public Guid User2Id { get; set; }

        public DateTime DateTime { get; set; }

		[Required]
		public bool IsFromUser1 { get; set; }
        public  bool AlredyExist { get; set; }
    }
}
