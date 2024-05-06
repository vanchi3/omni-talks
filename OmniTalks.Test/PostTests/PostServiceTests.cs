using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.CategoryViewModels;
using OmniTalks.Models.Domein;
using OmniTalks.Models.PostViewModel;
using OmniTalks.Models.UserViewModels;
using OmniTalks.Services;

namespace OmniTalksTestProject
{
    [TestFixture]
    public class PostServiceTests
    {
        private IEnumerable<Post> _posts;
        private IEnumerable<User> _users;
        private IEnumerable<Category> _category;
        private IEnumerable<Comment> _comments;
        private IPostService _postService;
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
                    Id=new Guid(),
                    Text = "TestCommentText",
                    UserId=new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460"),
                    PostId = new Guid("ce196f7e-6beb-42f8-a03f-4cc2da97b292")
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
            this._context.SaveChanges();
            _postService = new PostService(this._context);
        }

        [TestCase("TestNewPostContent")]
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin condimentum purus felis, vitae blandit justo finibus eu. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Ut at luctus magna, id rhoncus ex. Proin maximus, lorem non feugiat auctor, nisi lectus dapibus velit, quis dignissim lorem mauris ut leo. Ut varius tempus neque eu ornare. Phasellus ultrices ligula non nisl gravida, sed accumsan nulla euismod. Nullam non blandit ligula. Morbi posuere urna vitae dui elementum sagittis. Interdum et malesuada fames ac ante ipsum primis in faucibus. Proin id purus ac ipsum fermentum malesuada viverra a elit.\r\n\r\nEtiam ac pretium justo. Nullam placerat commodo lectus pulvinar pellentesque. Suspendisse bibendum ullamcorper nisi in fringilla. Etiam congue ut metus nec maximus. Sed ut nulla ac tortor venenatis dignissim et ac quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Suspendisse vel mollis neque. Mauris nec massa lacus.\r\n\r\nQuisque consequat risus risus, non egestas sem commodo sed. Proin eget consectetur neque. Proin euismod malesuada nibh. Vestibulum id commodo leo. Ut purus ligula, tristique ut placerat non, blandit lacinia dui. Aliquam suscipit orci in consectetur consectetur. Vestibulum non tempor sem. Aenean bibendum tincidunt lorem a bibendum. Etiam et cursus elit. Donec sollicitudin consectetur mi, vitae tincidunt velit eleifend id.\r\n\r\nUt blandit dictum urna. Nam maximus erat sed accumsan sagittis. Nunc velit ligula, lobortis non magna sed, tristique varius magna. Sed felis elit, maximus nec sollicitudin vitae, dictum vitae mi. Phasellus ut faucibus nulla, non dignissim nisi. Sed quam libero, tempor et venenatis nec, congue nec est. Mauris dictum tortor ex, ac porta neque pretium sed. Morbi quis felis urna. Curabitur vitae turpis sed est mollis pharetra.\r\n\r\nProin vel mollis turpis. Integer laoreet eleifend arcu, rutrum tincidunt urna blandit ut. Nunc a quam id nibh venenatis ornare eget quis mi. Proin ac eros vel velit iaculis aliquet. Ut non purus enim. Mauris vehicula purus eleifend nunc euismod finibus. Nullam non facilisis erat. Maecenas et nunc vel nunc convallis eleifend et at metus. Suspendisse a vehicula eros. Morbi auctor ipsum at vulputate tincidunt. Sed vitae imperdiet lacus. Duis eu hendrerit felis. Sed sollicitudin nisi leo, a iaculis mi aliquam non. Suspendisse mollis leo dictum lectus fringilla, eget ullamcorper leo laoreet. Phasellus sollicitudin lectus sed mi varius, non dignissim mi maximus.")]
        public async Task PostIsAddedWhenCallingAddWithCorrectData(string content)
        {
            //Arrange
            PostViewModel model = new PostViewModel()
            {
                Id = new Guid("0027411d-ffb2-4ca1-a269-7588be21dbd4"),
                UserName = "TestSubgect",
                Content = content,
                CategoryId = new Guid("a58038eb-e072-420c-9ffa-29047b85523d"),
                CreatedDate = DateTime.Now,
                UserPhotoUrl = "/images/avatar-7.png"
            };

            //Act
            await _postService.Add(model, "9dd5d367-117f-4f55-af05-dfdaba7c3460");

            bool expected = await _context.Posts.AnyAsync(x => x.Content == model.Content);
            //Assert
            Assert.True(expected);
        }
        [TestCase("TestPostContent")]
        public async Task EditPostTest(string content)
        {
            //Arrange
            PostViewModel model = new PostViewModel()
            {
                Id = new Guid("ce196f7e-6beb-42f8-a03f-4cc2da97b292"),
                UserName = "TestSubgect",
                Content = content,
                CategoryId = new Guid("a58038eb-e072-420c-9ffa-29047b85523d"),
                CreatedDate = DateTime.Now,
                UserPhotoUrl = "/images/avatar-7.png"

            };

            //Act
            await _postService.Edit(model);

            bool expected = await _context.Posts.AnyAsync(x => x.Content == model.Content);
            //Assert
            Assert.True(expected);
        }
         [Test]
        public async Task PostIsRemovedWhenCalledCorrectlu()
        {
            //Arenge
            Guid postId = new Guid("ce196f7e-6beb-42f8-a03f-4cc2da97b292");
            string content = "TestPostContent1";
            Guid userId = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460");
            //Act
            await _postService.Remove(postId, userId, true);
            bool expected = await _context.Posts.AnyAsync(x => x.Content == content);
            //Assert
            Assert.False(expected);
        }

        [Test]
        public async Task IsPostViewModelNotNullWhenGettingPostInformation()
        {
            PostViewModel model = await _postService.GetById(new Guid("ce196f7e-6beb-42f8-a03f-4cc2da97b292"));

            Assert.NotNull(model);
        }

        [Test]
        public async Task IsPostViewModelTheSameWhenGettingPostInformation()
        {
            Guid postId = new Guid("ce196f7e-6beb-42f8-a03f-4cc2da97b292");

            PostViewModel model = await _postService.GetById(postId);
            string rightContent = _posts.Where(x => x.Id == postId).FirstOrDefault().Content;
            Assert.True(model.Content == rightContent);
        }
    }
}
