using Mozer.Models.Accounts.Entities;
using Mozer.ViewModels.UserDtos.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Business.User.Abstraction
{
    public interface IUserService
    {
        Task<IEnumerable<UserListForHomeDto>> GetUsersForApp(Guid? notId = null);
        Task<UserModel> GetUserByUserName(string UserName);
        Task<UserModel> GetUserById(Guid Id);
    }
}
