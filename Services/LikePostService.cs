using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models;
using OmniTalks.Models.Domein;

namespace OmniTalks.Services
{
    public class LikePostService : ILikeService
    {
        public ApplicationDbContext _context;

        public LikePostService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(PostLikeViewModel model)
        {
            PostLike like = new PostLike() 
            { 
                Id = new Guid(),
                PostId =  model.PostId,
                Post = await _context.Posts.FindAsync(model.PostId),
                UserId = model.UserId,
                User = await _context.Users.FindAsync(model.UserId)
                
            };

            _context.PostsLikes.Add(like);
            _context.SaveChanges();
        }
    }
}
