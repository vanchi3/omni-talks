using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniTalks.Contracs;
using OmniTalks.Models.ChatViewModels;

namespace OmniTalks.Controllers
{
	[Authorize]
	public class ChatController : BaseController
	{
		private IChatService _chatService;
		private IUserService _userService;

		public ChatController(IChatService chatService, IUserService userService)
		{
			_chatService = chatService;
			_userService = userService;
		}

		[HttpGet]
		public async Task<IActionResult> ShowChat(Guid id)
		{
			Guid currentUser = new Guid(CurrentUserId);

			if (id == currentUser)
			{
				return NotFound();
			}

			await _chatService.AddChat(currentUser, id);

			var user = await _userService.GetById(id);

			if (user == null)
			{
				return NotFound();
			}

			ChatViewModel model = new ChatViewModel()
			{
				Reciever = user,
				Messages = await _chatService.ShowMessages(currentUser, id),
				SidebarChats = await _chatService.ShowAllChats(new Guid(CurrentUserId)),
				CurrentChatId = id
			};

			if (!ModelState.IsValid)
			{
				return Redirect($"/Chat/ShowChat/{model.Reciever.Id}");
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddMessage(MessageViewModel model)
		{
			var sendToUser = model.User2Id;

			if (!ModelState.IsValid)
			{
				return Redirect($"/Chat/ShowChat/{sendToUser}");
			}

			model.User1Id = new Guid(CurrentUserId);
			var isAdded = await _chatService.AddMessage(model);

			if (!isAdded)
			{
				return BadRequest();
			}

			return Redirect($"/Chat/ShowChat/{model.User2Id}");
		}

		//[HttpGet]
		//public IActionResult EditMessage(Guid id)
		//{
		//	MessageViewModel model = new MessageViewModel();
		//	model.User2Id = id;
		//	model.AlredyExist = true;
		//	if (!ModelState.IsValid)
		//	{
		//		return Redirect($"/Chat/ShowChat/{model.User2Id}");
		//	}
		//
		//	model.User1Id = new Guid(CurrentUserId);
		//	model.AlredyExist = true;
		//
		//	return Redirect($"/Chat/ShowChat/{model.User2Id}");
		//}
		//[HttpPost]
		//public async Task<IActionResult> EditMessage(MessageViewModel model)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return Redirect($"/Chat/ShowChat/{model.User2Id}");
		//	}
		//
		//	model.User1Id = new Guid(CurrentUserId);
		//	model.AlredyExist = true;
		//	var isAdded = await _chatService.EditMessage(model);
		//
		//	if (!isAdded)
		//	{
		//		return BadRequest();
		//	}
		//
		//	return Redirect($"/Chat/ShowChat/{model.User2Id}");
		//}
		[HttpGet]
		public async Task<IActionResult> ShowAllChats()
		{
			return View();
		}
		//[HttpGet]
		//public async Task<IActionResult> _ShowMessages()
		//{
		//	Guid currentId = new Guid(CurrentUserId);
		//	List<ShowMessageViewModel> models = await _chatService.ShowMessages(currentId);
		//	return View(models);
		//}
	}
}
