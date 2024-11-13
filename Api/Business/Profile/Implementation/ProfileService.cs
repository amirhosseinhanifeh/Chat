using Microsoft.EntityFrameworkCore;
using Mozer.Business.Profile.Abstraction;
using Mozer.Business.Upload.Abstraction;
using Mozer.DataAccess.Common.Abstraction;
using Mozer.ViewModels.ProfileDtos;
using Mozer.ViewModels.UserDtos.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mozer.Business.Profile.Implementation
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _uploadService;

        public ProfileService(IUnitOfWork unitOfWork, IUploadService uploadService)
        {
            _unitOfWork = unitOfWork;
            _uploadService = uploadService;
        }

        public async Task<string> GetConnectionId(Guid userId)
        {
            var user = await _unitOfWork.ProfileRepository.AsQueryable()
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.UserId == userId);
            return user?.ConnectionId ?? null;
        }

        public async Task<ProfileForHomeDto> Getprofile(Guid userId, Guid profileId)
        {
            var user = await _unitOfWork.ProfileRepository.AsQueryable()
                .Include(x => x.User)
                .ThenInclude(h => h.Messages)
                .Include(x=>x.User.UserRelations)
                .Include(x=>x.User.FriendRelations)
                .FirstOrDefaultAsync(x => x.UserId == profileId);

            return new ProfileForHomeDto
            {
                Id = userId,
                Avatar = "https://localhost:44327/Uploads/Avatar/"+ user.Avatar,
                FullName = user.Name,
                MessageId = user.User.Messages.FirstOrDefault(h => (h.SenderId == userId && h.ReciverId == profileId) || (h.SenderId == profileId && h.ReciverId == userId))?.Id,
                IsBlock=user.User.UserRelations.Any(h=>h.FriendId==userId && h.RelationType==Models.Relation.Entities.RelationTypeEnum.Block)

            };
        }

        public async Task UpdateConnectionId(Guid userId, string ConnectionId)
        {
            var user = await _unitOfWork.ProfileRepository.AsQueryable()
                .FirstOrDefaultAsync(x => x.UserId == userId);
            user.ConnectionId = ConnectionId;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateProfile(Guid userId, UpdateProfileDto model)
        {
            var user = await _unitOfWork.ProfileRepository.Get(x => x.UserId == userId);
            if (model.Image != null)
            {
                user.Avatar = (await _uploadService.UploadAsync(model.Image, user.UserId.ToString(), "Uploads/Avatar")).Name;
            }
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
