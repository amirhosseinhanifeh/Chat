using Microsoft.EntityFrameworkCore;
using Mozer.Business.User.Abstraction;
using Mozer.DataAccess.Common.Abstraction;
using Mozer.Models.Accounts.Entities;
using Mozer.ViewModels.UserDtos.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Business.User.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserModel> GetUserById(Guid Id)
        {
            return await _unitOfWork.UserRepository.Get(x => x.Id == Id);
        }

        public async Task<UserModel> GetUserByUserName(string UserName)
        {
            return await _unitOfWork.UserRepository.Get(x => x.UserName == UserName);
        }

        public async Task<IEnumerable<UserListForHomeDto>> GetUsersForApp(Guid? notId=null)
        {
            var result = _unitOfWork.UserRepository.AsQueryable()
                .Include(x => x.Profile)
                .Where(x => x.IsDeleted != true);
            if(notId !=null)
                result=result.Where(h=>h.Id !=notId);

            return result.Select(x => new UserListForHomeDto
            {
                Avatar = "https://localhost:44327/Uploads/Avatar/" + x.Profile.Avatar,
                FullName = x.Profile.Name,
                Id = x.Id,
                UserName=x.UserName
            });
        }
    }
}
