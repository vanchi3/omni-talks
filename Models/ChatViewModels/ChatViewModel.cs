using OmniTalks.Models.Domein;

namespace OmniTalks.Models.ChatViewModels
{
	public class ChatViewModel
	{
        public Guid CurrentChatId { get; set; }
        public User Reciever { get; set; } = null!;
		public List<ShowMessageViewModel> Messages { get; set; } = [];
		public List<HeaderChatViewModel> SidebarChats { get; set; } = [];
    }
}
