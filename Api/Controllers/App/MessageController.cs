using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mozer.Business.Message.Abstraction;
using Mozer.ViewModels.UserDtos.App.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mozer.Controllers.App
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var user = Guid.Parse(User.Identity.Name);
            return Ok(await _messageService.GetMessages(user));
        }

        [HttpGet]
        public async Task<IActionResult> GetChats(Guid RoomId, int page = 1)
        {
            var user = Guid.Parse(User.Identity.Name);
            var room = await _messageService.GetRoom(RoomId);
            var userInfoId = room.SenderId == user ? room.Reciver : room.Sender;
            return Ok(new
            {
                userInfo = new
                {
                    Name = userInfoId.Profile.Name,
                    Avatar = "https://localhost:44327/Uploads/Avatar/"+userInfoId.Profile.Avatar
                },
                chats = await _messageService.GetChats(RoomId, user, page)
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateConversation([FromBody] CreateMessageDto model, CancellationToken cancellationToken)
        {
            var result = await _messageService.CreateConversation(Guid.Parse(User.Identity.Name), model.reciverId);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(Guid id)
        {
            var user = Guid.Parse(User.Identity.Name);
            await _messageService.DeleteMessage(id, user);
            return Ok();
        }
    }
}
