using Mozer.DataAccess.Common.Repositories.Implementation;
using Mozer.DataAccess.Messages.Abstraction;
using Mozer.Models.Messages.Entities;
using Mozer.ServiceContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.DataAccess.Messages.Implementation
{
    public class MessageRepository: Repository<MessageModel>, IMessageRepository
    {
        public MessageRepository(MozerContext context) : base(context)
        {

        }
    }
}
