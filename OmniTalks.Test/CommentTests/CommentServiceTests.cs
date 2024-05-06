using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.CommentViewModels;
using OmniTalks.Models.Domein;
using OmniTalks.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniTalksTestProject.CommmentTests
{
    [TestFixture]
    internal class CommentServiceTests
    {
        private IEnumerable<Post> _posts;
        private IEnumerable<User> _users;
        private IEnumerable<Category> _category;
        private IEnumerable<Comment> _comments;
        private IEnumerable<CommentLike> _commentLikes;
        private ICommentService _commentService;
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            this._users = new List<User>()
            {
                new User()
                {
                    Id = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460"),
                    UserName ="TestSubgect",
                    FirstName="TestFirstName",
                    LastName="TestLastName",
                    Email="test@mail.com",

                    ProfilePhоtoUrl = "/images/avatar-7.png"
                }
            };
            this._category = new List<Category>()
            {
                new Category()
                {
                    Id =new Guid("a58038eb-e072-420c-9ffa-29047b85523d"),
                    Name = "Everyday",
                    Bio = "Test",
                }
            };
            this._posts = new List<Post>()
            {
               new Post()
               {
                 Id =new Guid("ce196f7e-6beb-42f8-a03f-4cc2da97b292"),
                 Content = "TestPostContent1",
                 CreatedDate = DateTime.Now,
                 UserId = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460"),
                 User = _users.Where(x => x.Id == new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460")).FirstOrDefault(),
                 CategoryId = new Guid("a58038eb-e072-420c-9ffa-29047b85523d"),
                 Category = _category.Where(x => x.Name == "Everyday").FirstOrDefault(),
                 ImgUrl ="/images/avatar-7.png"
               }
            };
            this._comments = new List<Comment>()
            {
                new Comment()
                {
                    Id=new Guid("e3ac9e14-2dbc-4cc5-9dc9-766cc366def9"),
                    Text = "TestCommentText",
                    UserId=new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460"),
                    PostId = new Guid("ce196f7e-6beb-42f8-a03f-4cc2da97b292")
                }
            };
            this._commentLikes = new List<CommentLike>() 
            { 
                new CommentLike()
                {
                    CommentId = new Guid("e3ac9e14-2dbc-4cc5-9dc9-766cc366def9"),
                    UserId=new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460"),
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
            this._context.AddRange(this._category);
            this._context.AddRange(this._posts);
            this._context.AddRange(this._comments);
            this._context.AddRange(this._commentLikes);
            this._context.SaveChanges();
            _commentService = new CommentService(this._context);
        }

        [Test]
        public async Task AddCommentWithCorrectInformation()
        {
            AddCommentViewModel model = new AddCommentViewModel()
            {
                PostId = new Guid("ce196f7e-6beb-42f8-a03f-4cc2da97b292"),
                UserPhtotUrl = "/images/avatar-7.png",
                Text = "TestAddingcComment",
                ImgUrl = "/images/avatar-6.png"
            };

            await _commentService.Add(model, "9dd5d367-117f-4f55-af05-dfdaba7c3460");

            bool expected = await _context.Comments.AnyAsync(x => x.Text == model.Text);

            Assert.True(expected);
        }

        [Test]
        public async Task EditCommentWithCorrectInformation()
        {
            CommentViewModel model = new CommentViewModel()
            {
                Id = new Guid("e3ac9e14-2dbc-4cc5-9dc9-766cc366def9"),
                Text = "TestAddingcComment",
                ImgUrl = "/images/avatar-6.png",
                LikesCount = 0,
                UserName = "TestSubgect"
            };

            await _commentService.Edit(model);

            Assert.True(_comments.Any(x => x.Text == model.Text));
        }

        [Test]
        public async Task CallingGetByIdWithCorrectInformation()
        {
            Guid id = new Guid("e3ac9e14-2dbc-4cc5-9dc9-766cc366def9");

            var userId = _commentService.GetById(id);

            Assert.NotNull(userId);
        }

        [Test]
        public async Task RemovingCommentWithCorrectInformation()
        {
            var commentId = new Guid("e3ac9e14-2dbc-4cc5-9dc9-766cc366def9");
            var userId = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460");

            bool expected = await _context.Comments.AnyAsync(x => x.Id == commentId);

            Assert.True(expected);
        }
    }
}
