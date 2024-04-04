using Microsoft.AspNetCore.Mvc;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models;
using OmniTalks.Models.Domein;

namespace OmniTalks.Services
{
    public class MessageService : IMessageService
    {
        private ApplicationDbContext _context;

        public MessageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(MessageViewModel model)
        { 
            Message message = new Message();
            message.Id = new Guid();
            message.Text = model.Text;
            message.SentTime = DateTime.Now;
            
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
    }
}
