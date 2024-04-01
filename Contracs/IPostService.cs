using OmniTalks.Models;
using OmniTalks.Models.Domein;

namespace OmniTalks.Contracs
{
    public interface IPostService
    {
        public Task Add(PostViewModel model,string currentId);
        public Task<List<PostViewModel>> All();
        public Task Remove(Guid id,Guid userId);
        public Task Edit(PostViewModel model);
        //public Task<PostViewModel> Rewrite(Guid id);
        public Task<PostViewModel> GetById(Guid id);

	}
}
