using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace OmniTalks.Models.Domein
{
	public class Connection
	{
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        public List<UserConnection> UserConnections { get; set; } = [];
    }
}
