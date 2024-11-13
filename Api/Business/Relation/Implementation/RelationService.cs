using Mozer.Business.Relation.Abstraction;
using Mozer.DataAccess.Common.Abstraction;
using Mozer.Models.Relation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Business.Relation.Implementation
{
    public class RelationService : IRelationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RelationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SetRelation(Guid userId, Guid friendId, RelationTypeEnum relationType)
        {
            _unitOfWork.RelationRepository.Add(new RelationModel
            {
                UserId = userId,
                FriendId = friendId,
                RelationType = relationType
            });
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
