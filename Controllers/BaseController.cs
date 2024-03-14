using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OmniTalks.Controllers
{
    public class BaseController : Controller
    {
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
