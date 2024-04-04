using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models;
using OmniTalks.Models.Domein;
using System.Security.Claims;


namespace OmniTalks.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(PostViewModel model, string currentId)
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
            List<PostViewModel> postViewModels = await _context.Posts
                .Include(p => p.PostLikes)
                .Include(p => p.User)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Content = p.Content,
                    UserName = p.User.UserName,
                    UserId = p.User.Id,
                    Comments = p.Comments.Select(c => new CommentViewModel()
                    {
                        Id = c.Id,
                        Text = c.Text,
                        UserName = c.User.UserName,
                        LikesCount = c.CommentLikes.Count(),
                    }).ToList(),
                    LikesCount = p.PostLikes.Count()
                })
                .ToListAsync();

            return postViewModels;
        }

        public async Task<PostViewModel> GetById(Guid id)
        {
            Post post = await this._context.Posts.FindAsync(id);
            PostViewModel pvm = new PostViewModel();
            pvm.Id = id;
            pvm.Content = post.Content;
            pvm.UserId = post.UserId;
            return pvm;
        }

        public async Task Edit(PostViewModel model)
        {
            Post post = await this._context.Posts.FindAsync(model.Id);
            post.Content = model.Content;

            await _context.SaveChangesAsync();
        }

        public async Task Remove(Guid id, Guid userId)
        {
            var post = await _context.Posts
                .FirstOrDefaultAsync(x => x.Id == id);

            if (post.UserId == userId)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

		//public async Task<PostViewModel> Rewrite(Guid id)
		//{
		//	var post = await _context.Posts.FindAsync(id);
		//	PostViewModel model = new PostViewModel();
		//	model.Content = post.Content;
        //
		//	return model;
		//}
	}
}

