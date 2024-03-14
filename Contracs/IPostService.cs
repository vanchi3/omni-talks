using OmniTalks.Models;

namespace OmniTalks.Contracs
{
    public interface IPostService
    {
        public Task Add(PostViewModel model,string currentId);
        public Task<List<PostViewModel>> All();

    }
}
