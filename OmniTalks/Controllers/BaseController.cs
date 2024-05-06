using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OmniTalks.Contracs;
using OmniTalks.Models.ChatViewModels;
using System.Security.Claims;

namespace OmniTalks.Controllers
{
	public class BaseController : Controller
	{
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var controller = context.Controller as Controller;
			var service = context.HttpContext.RequestServices.GetService<IChatService>();
			if ((User?.Identity?.IsAuthenticated ?? false) && controller != null && service != null)
			{
				List<HeaderChatViewModel> chats = await service.ShowAllChats(new Guid(CurrentUserId));
				controller.ViewData["HeaderChatsMessages"] = chats;
				controller.ViewData["UserProfilePhoto"] = UserProfilePhoto;
			}


			await next();
		}
		public string UserName
		{
			get
			{
				string? username = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
				username = username ?? "Guest";

				return username;
			}
		}
		public string CurrentUserId
		{
			get
			{
				string? nameId = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
				nameId = nameId ?? "00000000-0000-0000-0000-000000000000";

				return nameId;
			}
		}

		public string UserProfilePhoto
		{
			get
			{
				string? profilePhoto = User?.Claims?.FirstOrDefault(x => x.Type == "user-profile-photo")?.Value;
				profilePhoto = profilePhoto ?? "/images/avatar-7.png";

				return profilePhoto;
			}
		}


		public bool IsAdmin
		{
			get
			{
				return this.User.IsInRole("Admin");
			}
		}

	}
}
