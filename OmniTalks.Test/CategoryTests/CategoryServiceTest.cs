using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.Domein;
using OmniTalks.Models.CategoryViewModels;
using OmniTalks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniTalksTestProject.CategoryTests
{
    [TestFixture]
    internal class CategoryServiceTest
    {
        private IEnumerable<Post> _posts;
        private IEnumerable<User> _users;
        private IEnumerable<Category> _categories;
        private ICategoryService _categoryService;
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
            this._categories = new List<Category>()
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
                 Category = _categories.Where(x => x.Name == "Everyday").FirstOrDefault(),
                 ImgUrl ="/images/avatar-7.png"
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
            this._context.AddRange(this._categories);
            this._context.AddRange(this._posts);
            this._context.SaveChanges();
            _categoryService = new CategoryService(this._context);
        }

        [Test]
        public async Task AddWithCategoryCorrectInformation()
        {
            CategoryViewModel model = new CategoryViewModel()
            {
                Id = new Guid("57552175-2deb-4c1b-b2c1-9c7bec9252ae"),
                Name = "TestCategoryName",
                Bio = "TestForCategoryName",
            };

            await this._categoryService.Add(model);
            bool expected = await _context.Categories.AnyAsync(x => x.Name == "TestCategoryName");

            Assert.True(expected);
        }

        [Test]
        public async Task GetAllCategoriesWithCorrectInformation()
        {
            List<CategoryViewModel> categoryViews = await _categoryService.GetAll();

            Assert.NotNull(categoryViews);
        }
    }
}
