using OmniTalks.Models;

namespace OmniTalks.Contracs
{
    public interface IMessageService
    {
        public Task Add(MessageViewModel model);

    }
}
