using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OmniTalks.Data.Configuraton;
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
		public DbSet<PostLike> PostsLikes { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<CommentLike> CommentsLikes { get; set; }
		public DbSet<Chat> Chats { get; set; }
		public DbSet<Follow> Follows { get; set; }
		public DbSet<Category> Categories { get; set; }

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
				.HasMany(u => u.SentedChat)
				.WithOne(s => s.User1)
				.HasForeignKey(s => s.User1Id)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Entity<User>()
				.HasMany(u => u.RecievedChat)
				.WithOne(r => r.User2)
				.HasForeignKey(r => r.User2Id)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Entity<User>()
				.HasMany(u => u.CommentLikes)
				.WithOne(cm => cm.User)
				.HasForeignKey(cm => cm.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Entity<User>()
				.HasMany(u => u.Followed)
				.WithOne(f => f.Followed)
				.HasForeignKey(f => f.FollowedId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Entity<User>()
			.HasMany(u => u.Followers)
			.WithOne(fw => fw.Follower)
			.HasForeignKey(fw => fw.FollowerId)
			.OnDelete(DeleteBehavior.NoAction);

			builder.Entity<Post>().Property(p => p.CreatedDate).HasDefaultValueSql("getdate()");
			builder.Entity<User>().Property(p => p.ProfilePhtotoUrl).HasDefaultValue("/images/avatar-7.png");

			// Composite Keys
			builder.Entity<PostLike>()
					.HasKey(pl => new { pl.UserId, pl.PostId });

			builder.Entity<CommentLike>()
					.HasKey(pl => new { pl.UserId, pl.CommentId });

			builder.ApplyConfiguration(new RoleConfiguration());
			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new UserRoleConfiguration());

			base.OnModelCreating(builder);
		}
	}
}
