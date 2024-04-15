using System.ComponentModel.DataAnnotations;

namespace OmniTalks.Models.UserViewModels
{
	public class LoginViewModel
	{
		[Required]
		[StringLength(30, MinimumLength = 3)]
		public string UserName { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[StringLength(20, MinimumLength = 6)]
		public string Password { get; set; }
	}
}
