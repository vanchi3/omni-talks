using OmniTalks.Models.Domein;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OmniTalks.Models
{
	public class ShowMessageViewModel
	{
		public Guid Id { get; set; }

		public string Text { get; set; } = null!;

		public DateTime SentTime { get; set; }

		public Guid ChatId { get; set; }

		public bool IsCurrent {  get; set; }
		public Chat Chat { get; set; } = null!;
	}
}
