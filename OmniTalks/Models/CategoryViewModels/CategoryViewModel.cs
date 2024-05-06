using OmniTalks.Models.Domein;

namespace OmniTalks.Models.CategoryViewModels
{
	public class CategoryViewModel
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
		public string Bio { get; set; }
		public List<Post> Posts { get; set; }
	}
}
