using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace OmniTalks.Models.Domein
{
	public class Connection
	{

        public Guid Id { get; set; }
        public string Status { get; set; }
        public List<UserConnection> UserConnections { get; set; }
    }
}
