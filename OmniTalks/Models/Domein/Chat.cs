using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
	public class Chat
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[ForeignKey(nameof(User2))]
		public Guid User2Id { get; set; }
		public User? User2 { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(User1))]
		public Guid User1Id { get; set; }
		public User? User1 { get; set; } = null!;

		public List<Message> Messages { get; set; } = [];

	}
}
