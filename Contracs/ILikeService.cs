using OmniTalks.Models;

namespace OmniTalks.Contracs
{
    public interface ILikeService
    {
        public Task Add(PostLikeViewModel model);
    }
}
