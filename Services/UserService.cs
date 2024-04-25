using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.Domein;
using OmniTalks.Models.PostViewModel;
using OmniTalks.Models.UserViewModels;
using System.Collections.Generic;

namespace OmniTalks.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> Conatins(Guid id, FollowerViewModel model)
        {
            bool contains = await _context.Follows?.AnyAsync(x => x.FollowedId == id && x.FollowerId == model.FollowerId);
            if (contains)
            {
                model.IsFollowing = true;
            }
            else
            {
                model.IsFollowing = false;
            }
            return contains;
        }

        public async Task<FollowerViewModel> FollowerAndFollowingDistribution(Guid currentUserId, Guid id, List<PostViewModel> models)
        {
            FollowerViewModel model = new FollowerViewModel
            {
                FollowerId = currentUserId,
                UserId = id,
                Following = await _context.Follows
                    .Include(f => f.Followed)
                    .Where(f => f.FollowerId == id)
                    .ToListAsync(),
                Followers = await this._context.Follows
                    .Include(f => f.Follower)
                    .Where(f => f.FollowedId == id)
                    .ToListAsync(),
                User = await _context.Users
                    .Where(x => x.Id == id)
                    .Select(u => new UserViewModel()
                    {
                        UserName = u.UserName,
                        ProfilePhotoUrl = u.ProfilePhtotoUrl
                    }).FirstOrDefaultAsync(),
                MyPosts = models
            };

            return model;
        }
       //Id = x.Id,
       //FollowerId = x.FollowerId,
       //        UserId = x.UserId,
       //        IsFollowing= x.IsFollowing,
        public async Task<List<UserViewModel>> Friends(Guid currentUserId)
        {

            List<UserViewModel> mutualFollowers = await this._context.Users
                .Where(u => u.Id == currentUserId)
                .Include(u => u.Followers)
                .Include(u => u.Followed)
                .Select(u => u.Followers.Intersect(u.Followed))
                .SelectMany(f => f)
                .Select(f => f.FollowedId == currentUserId ? f.Follower : f.Followed)
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    ProfilePhotoUrl = u.ProfilePhtotoUrl
                })
                .ToListAsync();

            return mutualFollowers;
        }
    }
}
