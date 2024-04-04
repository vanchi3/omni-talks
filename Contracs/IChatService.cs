using OmniTalks.Models;

namespace OmniTalks.Contracs
{
    public interface IChatService
    {
        public Task AddChat(Guid user1Id,Guid user2Id);
        public Task<bool> AddMessage(MessageViewModel model);
        public Task<List<ShowMessageViewModel>> ShowMessages(Guid currentUserId);
    }
}
