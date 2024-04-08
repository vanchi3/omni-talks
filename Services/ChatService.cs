using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models;
using OmniTalks.Models.Domein;
using System.Collections;
using System.ComponentModel;
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
            message.AlredyExist = true;
  
            await _context.SaveChangesAsync();
            return true;
        }

        private Expression<Func<Chat, bool>> ChatDelegate(object user1Id, object user2Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ShowMessageViewModel>> ShowMessages(Guid currentUserId)
        {
            List<ShowMessageViewModel> messageViewModels = await _context.Messages.Select(c => new ShowMessageViewModel()
            {

                Id = c.Id,
                Text = c.Text,
                SentTime = c.SentTime,
                ChatId = c.ChatId,
                Chat = c.Chat,
                IsCurrent = true

            })
                .OrderBy(x => x.SentTime)
                .ToListAsync();

            foreach (var messageVM in messageViewModels)
            {
                if (messageVM.Chat.User1Id != currentUserId)
                {
                    messageVM.IsCurrent = false;
                }
            }

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
                    Name = p.User1Id != currentUserId ? p.User1.UserName : p.User2.UserName,
                    LastText = p.Messages
                        .OrderByDescending(m => m.SentTime)
                        .Select(m => m.Text)
                        .LastOrDefault()
                }).ToListAsync();

            return chats;
        }
    }
}
