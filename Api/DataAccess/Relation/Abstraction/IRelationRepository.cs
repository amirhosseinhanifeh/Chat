using Mozer.DataAccess.Common.Repositories.Abstraction;
using Mozer.Models.Relation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.DataAccess.Relation.Abstraction
{
    public interface IRelationRepository : IRepository<RelationModel>
    {
    }
}
