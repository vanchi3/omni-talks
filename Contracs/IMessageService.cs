using OmniTalks.Models.ChatViewModels;

namespace OmniTalks.Contracs
{
	public interface IMessageService
	{
		public Task Add(MessageViewModel model);

	}
}
