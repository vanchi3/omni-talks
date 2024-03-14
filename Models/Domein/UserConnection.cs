using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models.Domein
{
	public class UserConnection
	{
		
		public Guid Id { get; set; }
	
		[ForeignKey(nameof(Domein.Connection))]
		public Guid ConnectonId { get; set; }
        public Connection Connection { get; set; }

        [ForeignKey(nameof(Domein.User))]
		public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
