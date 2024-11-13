using Mozer.Models.Relation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Business.Relation.Abstraction
{
    public interface IRelationService
    {
        Task SetRelation(Guid userId, Guid friendId, RelationTypeEnum relationType);
    }
}
