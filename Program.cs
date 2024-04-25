using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.Domein;
using OmniTalks.Services;
namespace OmniTalks
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("OmniTalkConnection") ?? throw new InvalidOperationException("Connection string 'OmniTalkConnection' not found.");
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(connectionString, opt => {
					opt.CommandTimeout(60);
					opt.EnableRetryOnFailure();
				});
			});
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();



			builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
				.AddRoles<IdentityRole<Guid>>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
			builder.Services.AddControllersWithViews();

			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/User/Login";
			});

			builder.Services.AddScoped<IPostService, PostService>();
			builder.Services.AddScoped<ILikeService, LikePostService>();
			builder.Services.AddScoped<ICommentService, CommentService>();
			builder.Services.AddScoped<IMessageService, MessageService>();
			builder.Services.AddScoped<IChatService, ChatService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IFollowSrvice, FollowService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			var app = builder.Build();


			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();


			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();
		}

	}
}
