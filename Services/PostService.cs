using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models;
using OmniTalks.Models.Domein;
using System.Security.Claims;


namespace OmniTalks.Services
{
    public class PostService:IPostService
    {
        public ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(PostViewModel model,string currentId)
        {
            Post post = new Post()
            {
                Id = Guid.NewGuid(),
                Content = model.Content,
                UserId = Guid.Parse(currentId)
            };

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PostViewModel>> All()
        {
            var posts = await _context.Posts.ToListAsync();

            var  postViewModels = posts.Select(x => new PostViewModel()
            {
                Content = x.Content,
                UserId = x.UserId,
                User = x.User,
                Comments = x.Comments

            })
            .ToList();

            return postViewModels;
        }
      
    }
}

