using System.ComponentModel.DataAnnotations;

namespace OmniTalks.Models.UserViewModels
{
	public class SideBarViewModel
	{
        public Guid Id { get; set; }
        public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? UserName { get; set; }

		public string? Email { get; set; }

		public string? Password { get; set; }

		public string? ConfirmPassword { get; set; }
	}
}
