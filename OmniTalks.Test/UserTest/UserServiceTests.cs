using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.Domein;
using OmniTalks.Models.UserViewModels;
using OmniTalks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniTalksTestProject.UserTest
{
    [TestFixture]
    internal class UserServiceTests
    {
        private IEnumerable<User> _users;
        private IUserService _userService;
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


            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;
            this._context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();
            this._context.Users.AddRange(this._users);
            this._context.SaveChanges();
            _userService = new UserService(this._context);
        }
        [Test]
        public async Task FollowerAndFollowingDistributionIsNotNull()
        {
            Guid CurreUserId = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460");
            Guid OtherUserId = new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62");

            FollowerViewModel model = await _userService.FollowerAndFollowingDistribution(CurreUserId, OtherUserId);
            
            Assert.IsNotNull(model);
        }

        [Test]
        public async Task FriendsIsNotNullWhenCalledWithCorrectInformation()
        {
            Guid CurreUserId = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460");

            List<UserViewModel> friends = await _userService.Friends(CurreUserId);

            Assert.IsNotNull(friends);
        }

        [Test]
        public async Task GetByIdUserIsNotNullWhenCalledWithCorrectInformation()
        {
            Guid CurreUserId = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460");

            User user = await _userService.GetById(CurreUserId);

            Assert.IsNotNull(user);
        }
    }
}
