using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.ChatViewModels;
using OmniTalks.Models.Domein;
using OmniTalks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniTalksTestProject.ChatTests
{
    [TestFixture]
    internal class ChatServiesTest
    {
        private IEnumerable<User> _users;
        private IEnumerable<Chat> _chats;
        private IEnumerable<Message> _messages;
        private IChatService _chatService;
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            this._users = new List<User>()
            {
                new User()
                {
                    Id = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460"),
                    UserName ="TestSubgectOne",
                    FirstName="TestFirstNameOne",
                    LastName="TestLastNameOne",
                    Email="testOne@mail.com",

                    ProfilePhоtoUrl = "/images/avatar-7.png"
                },
                new User()
                {
                    Id = new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62"),
                    UserName ="TestSubgectTwo",
                    FirstName="TestFirstNameTwo",
                    LastName="TestLastNameTwo",
                    Email="testTwo@mail.com",

                    ProfilePhоtoUrl = "/images/avatar-6.png"
                }
            };
            this._chats = new List<Chat>()
            {
                new Chat()
                {
                    Id =new Guid("a58038eb-e072-420c-9ffa-29047b85523d"),
                    User1Id=new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460"),
                    User2Id=new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62")
                }
            };
            this._messages = new List<Message>() 
            { 
                new Message()
                {
                    Id=new Guid("5be0d9e4-e78f-47bb-ab98-8cc5c4f1dbf1"),
                    IsFromUser1 = true,
                    ChatId=new Guid("a58038eb-e072-420c-9ffa-29047b85523d"),
                    Text = "TestMessegeText",
                    SentTime=DateTime.Now,
                }
            };


            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;
            this._context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();
            this._context.Users.AddRange(this._users);
            this._context.AddRange(this._chats);
            this._context.AddRange(this._messages);
            this._context.SaveChanges();
            _chatService = new ChatService(this._context);
        }

        [Test]
        public async Task ChatIsAddedWhenCallingAddWithCorrectData()
        {
            Guid userOneId = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460");
            Guid userTwoId = new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62");

            await _chatService.AddChat(userOneId,userTwoId);
            bool expected = await _context.Chats.AnyAsync(x => x.User1Id == userOneId && x.User2Id == userTwoId);

            Assert.True(expected);
        }

        [Test]
        public async Task MessagIsAddedWhenCallingAddWithCorrectData()
        {
            MessageViewModel model = new MessageViewModel() 
            { 
                Id = new Guid("e86dbd03-232b-4d58-88b8-f3b25a9f9e82"),
                Text = "MessageTextForAddTest",
                AlredyExist = false,
                DateTime = DateTime.Now,
                IsFromUser1 = true,
                User1Id = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460"),
                User2Id = new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62"),
            };


            await _chatService.AddMessage(model);
            bool expected = await _context.Messages.AnyAsync(x => x.Text == model.Text);

            Assert.True(expected);
        }

        [Test]
        public async Task GetAllMessagesWithCorrectInformation()
        {
            Guid userOneId = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460");
            Guid userTwoId = new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62");

            List<ShowMessageViewModel> messages = await _chatService.ShowMessages(userOneId,userTwoId);

            Assert.NotNull(messages);
        }

        [Test]
        public async Task GetAllChatsWithCorrectInformation()
        {
            Guid userOneId = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460");

            List<HeaderChatViewModel> chats = await _chatService.ShowAllChats(userOneId);

            Assert.NotNull(chats);
        }
    }
}

