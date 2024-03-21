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
		public ApplicationDbContext _context;

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
			var posts = await _context.Posts
				.Include(p => p.PostLikes)
				.Include(p => p.Comments)
				.ToListAsync();

			var postViewModels = posts.Select(p => new PostViewModel()
			{
				Id = p.Id,
				Content = p.Content,
				UserId = p.UserId,
				User = p.User,
				Comments = p.Comments,
				PostLikes = p.PostLikes.Select(pl => new PostLikeViewModel()
				{
					PostId = p.Id
				}).ToList()
			})
			.ToList();

			return postViewModels;
		}

		public async Task Edit(PostViewModel model, Guid id)
		{
			Post post = await this._context.Posts.FindAsync(id);
			post.Content = model.Content;
			post.User = model.User;
			post.UserId = model.UserId;
			post.Comments = model.Comments;

			await _context.SaveChangesAsync();
		}

		public async Task Remove(Guid id) 
		{


			var post = await _context.Posts
				.FirstOrDefaultAsync(x => x.Id == id);
			
			_context.Posts.Remove(post);
			await _context.SaveChangesAsync();
		}

	}
}

