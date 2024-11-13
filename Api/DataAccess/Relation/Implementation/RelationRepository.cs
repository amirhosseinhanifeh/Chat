using Mozer.DataAccess.Common.Repositories.Implementation;
using Mozer.DataAccess.Relation.Abstraction;
using Mozer.Models.Relation.Entities;
using Mozer.ServiceContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.DataAccess.Relation.Implementation
{
    public class RelationRepository:Repository<RelationModel>, IRelationRepository
    {
        public RelationRepository(MozerContext context) : base(context)
        {

        }
    }
}
