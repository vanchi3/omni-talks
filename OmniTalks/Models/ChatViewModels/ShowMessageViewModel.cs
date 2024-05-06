using OmniTalks.Models.Domein;

namespace OmniTalks.Models.ChatViewModels
{
	public class ShowMessageViewModel
	{
		public Guid Id { get; set; }

		public string Text { get; set; } = null!;

		public DateTime SentTime { get; set; }

		public Guid ChatId { get; set; }

		public bool IsCurrent { get; set; }
		public Chat Chat { get; set; } = null!;
	}
}
