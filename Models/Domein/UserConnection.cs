using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
	public class UserConnection
	{
		[Key]
		public Guid Id { get; set; }
	
		[ForeignKey(nameof(Connection))]
		public Guid ConnectonId { get; set; }
		public Connection Connection { get; set; } = null!;

        [ForeignKey(nameof(User))]
		public Guid UserId { get; set; }
		public User User { get; set; } = null!;
    }
}
