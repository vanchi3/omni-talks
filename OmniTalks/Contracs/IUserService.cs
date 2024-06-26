﻿using OmniTalks.Models.Domein;
using OmniTalks.Models.PostViewModel;
using OmniTalks.Models.UserViewModels;

namespace OmniTalks.Contracs
{
    public interface IUserService
    {
        Task<User?> GetById(Guid id);
        Task<bool> Conatins(Guid id, FollowerViewModel model);
        Task<FollowerViewModel> FollowerAndFollowingDistribution(Guid currenetUserId, Guid id);
        Task<List<UserViewModel>> Friends(Guid currentUserId);
    }
}