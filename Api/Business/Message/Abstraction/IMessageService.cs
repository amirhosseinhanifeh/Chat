using Mozer.Models.Messages.Entities;
using Mozer.ViewModels.MessageDtos.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mozer.Business.Message.Abstraction
{
    public interface IMessageService
    {
        Task<Guid> CreateConversation(Guid userId, Guid reciverId);
        Task<MessageItemModel> AddMessage(string Message,Guid userId, Guid RoomId);
        Task<IEnumerable<MessageItemsDto>> GetChats(Guid RoomId,Guid userId, int page = 1);
        Task<IEnumerable<MessageItemsDto>> GetMessages(Guid RoomId);
        Task<MessageItemsDto> GetMessage(Guid messageId,Guid userId);
        Task<MessageModel> GetRoom(Guid messageId);
        Task DeleteMessage(Guid Id, Guid userId);
    }
}
