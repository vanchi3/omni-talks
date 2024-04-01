using Microsoft.AspNetCore.Mvc;
using OmniTalks.Models;

namespace OmniTalks.Controllers
{
    public class MessageController : BaseController
    {
        public IActionResult Messages(Guid id)
        {
            MessageViewModel model = new MessageViewModel();
            model.SenderUserId = new Guid(CurrentUserId);
            model.RecieverUserId = new Guid();
            return View(model);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View("_AddMessage","Message");
        }
    }
}
