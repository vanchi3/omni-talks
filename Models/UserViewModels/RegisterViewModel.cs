using System.ComponentModel.DataAnnotations;

namespace OmniTalks.Models.UserViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[StringLength(30, MinimumLength = 3)]
		public string? FirstName { get; set; }

		[Required]
		[StringLength(30, MinimumLength = 3)]
		public string? LastName { get; set; }

		[Required]
		[StringLength(30, MinimumLength = 3)]
		public string? UserName { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(50, MinimumLength = 3)]
		public string? Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(20, MinimumLength = 6)]
		public string? Password { get; set; }

		[Compare(nameof(Password))]
		[DataType(DataType.Password)]
		public string? ConfirmPassword { get; set; }
	}
}
