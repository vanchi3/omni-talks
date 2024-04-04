using OmniTalks.Models.Domein;

namespace OmniTalks.Contracs
{
    public interface IUserService
    {
        Task<User?> GetById(Guid id);
    }
}