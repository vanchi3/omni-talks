using OmniTalks.Models.CommentViewModels;
using OmniTalks.Models.CategoryViewModels;

namespace OmniTalks.Models.PostViewModel
{
	public class PostViewModel
	{
		public Guid Id { get; set; }

		public string Content { get; set; }

		public string ImgUrl { get; set; }

		public string UserName { get; set; }

		public Guid UserId { get; set; }

        public Guid CurrentUserId { get; set; }

        public int LikesCount { get; set; }

		public CategoryViewModel Category { get; set; }
		public Guid CategoryId { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
		public List<CommentViewModel> Comments { get; set; }
	}
}
