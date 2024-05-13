using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.ChatViewModels;
using OmniTalks.Models.Domein;
using System.Linq.Expressions;

namespace OmniTalks.Services
{
    public class ChatService : IChatService
    {
        private ApplicationDbContext _context;

        public ChatService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddChat(Guid user1Id, Guid user2Id)
        {
            bool conatins = await _context.Chats.AnyAsync(ChatDelegate(user1Id, user2Id));

            if (conatins)
            {
                return;
            }

            Chat chat = new Chat()
            {
                Id = Guid.NewGuid(),
                User1Id = user1Id,
                User2Id = user2Id
            };
            await _context.AddAsync(chat);
            await _context.SaveChangesAsync();
        }

        private static Expression<Func<Chat, bool>> ChatDelegate(Guid user1Id, Guid user2Id)
        {
            return chat =>
                (chat.User1Id == user1Id && chat.User2Id == user2Id)
                || (chat.User1Id == user2Id && chat.User2Id == user1Id);
        }

        public async Task<bool> AddMessage(MessageViewModel messageModel)
        {
            Chat? chat = await _context.Chats
                .FirstOrDefaultAsync(ChatDelegate(messageModel.User1Id, messageModel.User2Id));

            if (chat == null)
            {
                return false;
            }

            Message message = new Message();
            message.Id = new Guid();
            message.Text = messageModel.Text;
            message.ChatId = chat.Id;
            message.SentTime = DateTime.Now;
            message.IsFromUser1 = chat.User1Id == messageModel.User1Id;

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditMessage(MessageViewModel messageModel)
        {
            Guid chatId = await _context.Chats
                .Where(ChatDelegate(messageModel.User1Id, messageModel.User2Id))
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            if (chatId == default)
            {
                return false;
            }

            Message message = new Message();
            message.Id = new Guid();
            message.Text = messageModel.Text;
            message.ChatId = chatId;
            message.SentTime = DateTime.Now;
            message.IsFromUser1 = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ShowMessageViewModel>> ShowMessages(Guid currentUserId, Guid recieverUserId)
        {
            List<ShowMessageViewModel> messageViewModels = await _context
                .Chats
                .Where(ChatDelegate(currentUserId, recieverUserId))
                .Include(m => m.Messages)
                .SelectMany(x => x.Messages)
                .Select(m => new ShowMessageViewModel()
                {
                    Id = m.Id,
                    Text = m.Text,
                    SentTime = m.SentTime,
                    ChatId = m.ChatId,
                    IsCurrent =
                        (m.IsFromUser1 && currentUserId == m.Chat.User1Id)
                        || (!m.IsFromUser1 && currentUserId == m.Chat.User2Id)
                })
                .OrderBy(x => x.SentTime)
                .ToListAsync();

            return messageViewModels;
        }

        public async Task<List<HeaderChatViewModel>> ShowAllChats(Guid currentUserId)
        {
            List<HeaderChatViewModel> chats = await _context.Chats
                .Include(ch => ch.User1)
                .Include(ch => ch.User2)
                .Include(ch => ch.Messages)
                .Where(ch => ch.User1Id == currentUserId || ch.User2Id == currentUserId)
                .Select(p => new HeaderChatViewModel()
                {
                    Id = p.Id,
					ProfileImgUrl = p.User1.ProfilePhоtoUrl,
					UserId = currentUserId == p.User1Id
                        ? p.User2Id
                        : p.User1Id,
                    Name = p.User1Id != currentUserId ? p.User1.UserName : p.User2.UserName,
                    LastText = p.Messages
                        .OrderBy(m => m.SentTime)
                        .Select(m => m.Text)
                        .LastOrDefault(),
				}).ToListAsync();

            return chats;
        }
    }
}
