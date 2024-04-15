namespace OmniTalks.Models.CommentViewModels
{
	public class CommentViewModel
	{
		public Guid Id { get; set; }

		public string Text { get; set; }

		public string UserName { get; set; }

		public int LikesCount { get; set; }
	}
}
