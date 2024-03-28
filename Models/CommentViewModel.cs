using OmniTalks.Models.Domein;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmniTalks.Models
{
	public class CommentViewModel
	{
		public Guid Id { get; set; }
		
		public string Text { get; set; }
        
		public string UserName { get; set; }

		public int LikesCount { get; set; }
	}
}
