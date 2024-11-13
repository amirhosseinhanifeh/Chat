using Mozer.DataAccess.Common.Repositories.Abstraction;
using Mozer.Models.Messages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.DataAccess.Messages.Abstraction
{
    public interface IMessageActionRepository : IRepository<MessageActionModel>
    {
    }
}
