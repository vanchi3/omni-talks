using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OmniTalks.Models.Domein;

namespace OmniTalks.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<Guid>,Guid>
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
            builder.Entity<Message>()
                .HasOne<User>(m => m.SenderUser)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Message>()
                .HasOne<User>(m => m.RecieverUser)
                .WithMany(u => u.RecievedMessages)
                .HasForeignKey(m => m.RecieverUserId)
                .OnDelete(DeleteBehavior.NoAction);

           //ok!
                builder.Entity<Comment>()
                .HasOne<Post>(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            // ok!
            builder.Entity<PostLike>()
                .HasOne<Post>(l => l.Post)
                .WithMany(p => p.PostLikes)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PostLike>()
				.HasKey(pl => new { pl.UserId, pl.PostId });

			builder.Entity<CommentLike>()
                .HasOne<Comment>(c => c.Comment)
                .WithMany(p => p.CommentLikes)
                .HasForeignKey(c => c.CommentId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);

        }
    }
}
