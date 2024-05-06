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

namespace OmniTalksTestProject.FollowTests
{
    [TestFixture]
    internal class FollowServiceTests
    {
        private IEnumerable<User> _users;
        private IEnumerable<Follow> _follows;
        private IFollowService _followService;
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
            this._follows = new List<Follow>()
            {
                new Follow()
                {
                    Id= new Guid("c25b827a-14e0-465c-b7f8-bfd4f098da1f"),
                    FollowedId= new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460"),
                    FollowerId= new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62"),
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
            this._context.AddRange(this._follows);
            this._context.SaveChanges();
            _followService = new FollowService(this._context);
        }

        [Test]
        public async Task FollowIsAddedSucsessfullyCallingAddWithCorrectData()
        {
            FollowerViewModel model = new FollowerViewModel() 
            {
                Id = new Guid("9aa03876-b52e-4464-833e-6df0bb6fdfb6"),
                FollowerId = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460"),
                UserId = new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62"),
                IsFollowing= false,
            };

            await _followService.Add(model, new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62"));

            bool expected = await _context.Follows.AnyAsync(x => x.Id == model.Id);

            Assert.True(expected);
        }

        [Test]
        public async Task FollowIsRemovedSucsessfullyCallingAddWithCorrectData()
        {
            FollowerViewModel model = new FollowerViewModel()
            {

                Id = new Guid("c25b827a-14e0-465c-b7f8-bfd4f098da1f"),
                UserId = new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460"),
                FollowerId = new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62"),
                IsFollowing = true,
            };

            await _followService.Remove(model, new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62"));

            bool expected = await _context.Follows.AnyAsync(x => x.FollowerId == new Guid("9dd5d367-117f-4f55-af05-dfdaba7c3460") && x.FollowedId == new Guid("d54ebe8c-1324-4760-84cb-a83065b7dc62"));

            Assert.False(expected);
        }
    }
}
