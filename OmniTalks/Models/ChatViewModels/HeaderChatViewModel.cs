namespace OmniTalks.Models.ChatViewModels
{
	public class HeaderChatViewModel
	{
		public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
		public string LastText { get; set; }

		public string ProfileImgUrl { get; set; }
	}
}
