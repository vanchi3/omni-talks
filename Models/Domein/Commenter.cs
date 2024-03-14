namespace OmniTalks.Models.Domein
{
    public class Commenter
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
