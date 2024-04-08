﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OmniTalks.Contracs;
using OmniTalks.Models;
using OmniTalks.Models.Domein;
using System.Security.Claims;

namespace OmniTalks.Controllers
{
    public class BaseController : Controller
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.Controller as Controller;
            var service = context.HttpContext.RequestServices.GetService<IChatService>();
            if ((User?.Identity?.IsAuthenticated  ?? false) && controller != null && service != null)
            {
                List<HeaderChatViewModel> chats = await service.ShowAllChats(new Guid(CurrentUserId));
                controller.ViewData["HeaderChatsMessages"] = chats;
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
                nameId = nameId ?? "Guest";

                return nameId;
            }
        }
    }
}
