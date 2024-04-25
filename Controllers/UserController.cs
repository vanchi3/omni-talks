using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OmniTalks.Contracs;
using OmniTalks.Data;
using OmniTalks.Models.CategoryViewModels;
using OmniTalks.Models.Domein;
using OmniTalks.Models.PostViewModel;
using OmniTalks.Models.UserViewModels;
using OmniTalks.Services;
using System.Security.Claims;

namespace OmniTalks.Controllers
{
	[Authorize]
	public class UserController : BaseController
	{
		private readonly UserManager<User> _userManger;
		private readonly SignInManager<User> _signInManager;
		private readonly RoleManager<IdentityRole<Guid>> _roleManager;
		private readonly IUserService _userService;
		private readonly IPostService _postService;
		private readonly ApplicationDbContext _context;

		public UserController(UserManager<User> userManger,
			SignInManager<User> signInManager,
			RoleManager<IdentityRole<Guid>> roleManager,
			IUserService userService,
			IPostService postService,
			ApplicationDbContext context)
		{
			_userManger = userManger;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_userService = userService;
			_postService = postService;
			_context = context;
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Home", "Index");
			}

			var model = new RegisterViewModel();

			if (!ModelState.IsValid)
			{
				return RedirectToAction("Register");
			}

			return View(model);
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var user = new User()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				UserName = model.UserName,
				ProfilePhtotoUrl = model.ProfilePhotoUrl
				
			};
			var result = await _userManger.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				return RedirectToAction("Login", "User");
			}
			foreach (var item in result.Errors)
			{
				ModelState.AddModelError("", item.Description);
			}
			return View(model);
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login()
		{
			var model = new LoginViewModel();

			return View(model);
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var user = await _context.Users.Where(x => x.UserName == model.UserName).FirstOrDefaultAsync();

			if (user != null)
			{
				var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

				if (result.Succeeded)
				{
					await _userManger.AddClaimAsync(user, new Claim("user-profile-photo", user.ProfilePhtotoUrl));

					return RedirectToAction("Index", "Home");
				}
			}
			ModelState.AddModelError("", "Invalid login");
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction("Login", "User");
		}


		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> OtherProfile(Guid id)
		{
			if (id == default)
			{
				if (this.User?.Identity?.IsAuthenticated ?? false)
				{
					id = new Guid(this.CurrentUserId);
				}
				else
				{
					return this.RedirectToAction("Login", "User");
				}
			}

			ViewBag.Username = UserName;
			ViewBag.CurrentUserId = new Guid(CurrentUserId);

			List<PostViewModel> models = await this._postService.All(id);

			FollowerViewModel model = await _userService.FollowerAndFollowingDistribution(new Guid(CurrentUserId), id, models);
			var contains = await _userService.Conatins(id, model);

			return View(model);
		}
	}
}
