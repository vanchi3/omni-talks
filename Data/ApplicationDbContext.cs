using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OmniTalks.Models.Domein;

namespace OmniTalks.Data
{
	public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Post> Posts { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Connection> Connections { get; set; }
		public DbSet<UserConnection> UserConnections { get; set; }
		public DbSet<PostLike> PostsLikes { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<CommentLike> CommentsLikes { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			// Fix Scaffolding
			builder.Entity<User>()
				.HasMany(u => u.Comments)
				.WithOne(c => c.User)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Entity<User>()
				.HasMany(u => u.Posts)
				.WithOne(p => p.User)
				.HasForeignKey(p => p.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Entity<User>()
				.HasMany(u => u.SentMessages)
				.WithOne(s => s.SenderUser)
				.HasForeignKey(s => s.SenderUserId)
				.OnDelete(DeleteBehavior.NoAction);
			
			builder.Entity<User>()
				.HasMany(u => u.RecievedMessages)
				.WithOne(r => r.RecieverUser)
				.HasForeignKey(r => r.RecieverUserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Entity<User>()
				.HasMany(u => u.CommentLikes)
				.WithOne(cm => cm.User)
				.HasForeignKey(cm => cm.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			// Composite Keys
			builder.Entity<PostLike>()
					.HasKey(pl => new { pl.UserId, pl.PostId });

            builder.Entity<CommentLike>()
                    .HasKey(pl => new { pl.UserId, pl.CommentId });

            base.OnModelCreating(builder);
		}
	}
}
