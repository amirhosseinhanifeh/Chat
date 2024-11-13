using Mozer.ViewModels.ProfileDtos;
using Mozer.ViewModels.UserDtos.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mozer.Business.Profile.Abstraction
{
    public interface IProfileService
    {
        Task<ProfileForHomeDto> Getprofile(Guid userId, Guid profileId);
        Task UpdateProfile(Guid userId, UpdateProfileDto model);
        Task<string> GetConnectionId(Guid userId);
        Task UpdateConnectionId(Guid userId, string ConnectionId);

    }
}
