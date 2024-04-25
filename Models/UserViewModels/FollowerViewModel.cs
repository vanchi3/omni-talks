using OmniTalks.Models.Domein;
using OmniTalks.Models.PostViewModel;
namespace OmniTalks.Models.UserViewModels
{
	public class FollowerViewModel
	{
		public Guid Id { get; set; }
		public Guid FollowerId { get; set; }
		public Guid UserId { get; set; }
		public UserViewModel User { get; set; }
		public List<Follow> Following { get; set; }
		public List<Follow> Followers { get; set; }
		public bool IsFollowing { get; set; }
        public List<PostViewModel.PostViewModel> MyPosts { get; set; }
    }
}
