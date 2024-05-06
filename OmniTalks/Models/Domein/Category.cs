namespace OmniTalks.Models.Domein
{
	public class Category
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }
		public List<Post> Posts { get; set; }
	}
}


