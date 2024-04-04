using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmniTalks.Data;
using OmniTalks.Models;
using OmniTalks.Models.Domein;
using System.Security.Claims;

namespace OmniTalks.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<User> _userManger;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ApplicationDbContext _context;

        public UserController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext context,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManger = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
                UserName = model.UserName
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
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Home", "Index");
            }

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
        public async Task<IActionResult> OtherProfile(Guid id)
        {
            UserViewModel model = new UserViewModel();
            model.Id = id;
            return View(model);
        }

    }
}
