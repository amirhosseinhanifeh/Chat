using Microsoft.EntityFrameworkCore;
using Mozer.Business.Message.Abstraction;
using Mozer.DataAccess.Common.Abstraction;
using Mozer.Models.Messages.Entities;
using Mozer.Models.Messages.Enums;
using Mozer.ServiceContext.DatabaseContext;
using Mozer.ViewModels.MessageDtos.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mozer.Business.Message.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MozerContext _context;
        public MessageService(IUnitOfWork unitOfWork, MozerContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<MessageItemModel> AddMessage(string Message, Guid userId, Guid RoomId)
        {
            var data = new MessageItemModel
            {
                Id = Guid.NewGuid(),
                MessageId = RoomId,
                MessageType = MessageTypeEnum.Text,
                SenderId = userId,
                Text = Message,

            };
            _unitOfWork.MessageItemRepository.Add(data);
            await _unitOfWork.SaveChangesAsync();
            return data;
        }

        public async Task<Guid> CreateConversation(Guid userId, Guid reciverId)
        {
            try
            {
                var data = _unitOfWork.MessageRepository.AsQueryable()
                    .Include(x => x.MessageItems)
                    .Where(x => (x.SenderId == userId && x.ReciverId == reciverId) || (x.SenderId == reciverId && x.ReciverId == userId)).FirstOrDefault();
                if (data == null)
                {
                    data = new MessageModel
                    {
                        SenderId = userId,
                        ReciverId = reciverId,

                    };
                    data.MessageItems = new List<MessageItemModel>();
                    _unitOfWork.MessageRepository.Add(data);
                    await _unitOfWork.SaveChangesAsync();
                }
                return data.Id;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task DeleteMessage(Guid Id, Guid userId)
        {
            var messageItems = await _unitOfWork.MessageItemRepository.GetList(x => x.MessageId == Id, new string[] { "MessageItemActions" });

            messageItems.ToList().ForEach(x =>
            {
                x.MessageItemActions.Add(new MessageItemActionModel
                {
                    MessageAction = MessageActionsEnum.DELETE,
                    UserId = userId,
                    MessageItemId = x.Id,

                });
            });
            _unitOfWork.MessageActionRepository.Add(new MessageActionModel
            {
                UserId = userId,
                MessageAction = MessageActionsEnum.DELETE,
                MessageId = Id
            });
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<MessageItemsDto>> GetChats(Guid RoomId, Guid userId, int page = 1)
        {
            var result = await _unitOfWork.MessageItemRepository.GetList(x => x.MessageId == RoomId && !x.MessageItemActions.Any(h => h.UserId == userId && h.MessageAction == MessageActionsEnum.DELETE), includes: new string[] { "Message", "Message.MessageActions", "Message.Sender", "Message.Reciver", "Sender", "Sender.Profile" });
            return result.OrderBy(h=>h.CreateDate).Select(x => new MessageItemsDto
            {
                MessageId = x.MessageId,
                ReciverName = x.Sender.Profile.Name,
                Date = x.CreateDate.ToShortDateString(),
                Message = x.Text,
                RoomId = x.Id,
                IsMe = x.SenderId == userId ? true : false,
                IsRead = x.IsRead
            });
        }

        public async Task<MessageItemsDto> GetMessage(Guid messageId, Guid userId)
        {
            return await _context.MessageItems.Where(x => x.Id == messageId).Select(x => new MessageItemsDto
            {
                RoomId = x.MessageId,
                MessageId = messageId,
                UserId = x.SenderId.Value,
                Date = x.CreateDate.ToLongDateString(),
                Message = x.Text,
                Avatar = "https://localhost:44327/Uploads/Avatar/" + x.Sender.Profile.Avatar,
                UserName = x.Sender.UserName,
                IsMe = x.SenderId == userId ? true : false,
                IsRead = x.IsRead
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MessageItemsDto>> GetMessages(Guid userId)
        {
            var result = await _unitOfWork.MessageRepository.GetList(x => (x.SenderId == userId || x.ReciverId == userId) && !x.MessageActions.Any(h => h.MessageAction == MessageActionsEnum.DELETE && h.UserId == userId), new string[] { "MessageActions", "Sender.Profile", "Reciver.Profile", "MessageItems" });
            return result.OrderByDescending(x => x.MessageItems.LastOrDefault().CreateDate).Select(x => new MessageItemsDto
            {
                RoomId = x.Id,
                UserId = x.ReciverId == userId ? x.SenderId : x.ReciverId.Value,
                ReciverName = x.ReciverId == userId ? x.Sender.Profile.Name : x.Reciver.Profile.Name,
                Date = x.MessageItems.LastOrDefault().CreateDate.ToLongDateString(),
                Message = x.MessageItems.OrderBy(x=>x.CreateDate).LastOrDefault()?.Text,
                Avatar = x.ReciverId == userId ? "https://localhost:44327/Uploads/Avatar/" + x.Sender.Profile.Avatar : "https://localhost:44327/Uploads/Avatar/" + x.Reciver.Profile.Avatar,
                UserName = x.ReciverId == userId ? x.Sender.UserName : x.Reciver.UserName,
                IsMe = x.SenderId == userId ? true : false,
            });
        }

        public async Task<MessageModel> GetRoom(Guid messageId)
        {
            return await _unitOfWork.MessageRepository.Get(x => x.Id == messageId, includes: new string[] { "Sender", "Reciver", "Sender.Profile", "Reciver.Profile" });
        }
    }
}
