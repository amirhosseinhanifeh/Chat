using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mozer.Business.Message.Abstraction;
using Mozer.Business.Profile.Abstraction;
using Mozer.Business.User.Abstraction;
using Mozer.ServiceContext.DatabaseContext;
using Mozer.ViewModels.MessageDtos.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mozer.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;
        private readonly MozerContext _db;

        private readonly IServiceScopeFactory _scopeFactory;
        public ChatHub(IMessageService messageService, IServiceScopeFactory scopeFactory, MozerContext db)
        {
            _messageService = messageService;
            _scopeFactory = scopeFactory;
            _db = db;
            //await _messageService.CreateConversation(message, user, reciver.Id);
        }
        public Task JoinToGroup(string RoomId)
        {
            var connection = Context.ConnectionId;
            Groups.AddToGroupAsync(connection, RoomId.ToString());
            return Task.CompletedTask;
        }
        public async Task SendMessage(Guid RoomId, string message)
        {
            var room = await _messageService.GetRoom(RoomId);
            var res = await _messageService.AddMessage(message, Guid.Parse(Context.User.Identity.Name), RoomId);
            var result = await _messageService.GetMessage(res.Id, Guid.Parse(Context.User.Identity.Name));
            await Clients.GroupExcept(RoomId.ToString(), Context.ConnectionId).SendAsync("ReceiveMessage", Guid.Parse(Context.User.Identity.Name) == room.SenderId ? room.SenderId : room.ReciverId, result);
        }
        public override Task OnConnectedAsync()
        {
            var connection = Context.ConnectionId;
            var user = Context.User.Identity.Name;
            Task.Run(() =>
            {
                var scope = _scopeFactory.CreateScope();
                var result = scope.ServiceProvider.GetRequiredService<IProfileService>();
                if (user != null)
                {
                    result.UpdateConnectionId(Guid.Parse(user), connection);
                }

            });
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);

        }
        public async Task IsTyping(Guid RoomId)
        {
            await Clients.GroupExcept(RoomId.ToString(), Context.ConnectionId).SendAsync("IsTyping", "در حال نوشتن ...");
        }
        public async Task Read(Guid RoomId)
        {
            var result = await _db.MessageItems.Where(x => x.MessageId == RoomId && x.IsRead == false).ToListAsync();
            if (result.Count() > 0)
            {
                result.ForEach(h =>
                {
                    h.IsRead = true;
                });
                await _db.SaveChangesAsync();

            }
            await Clients.GroupExcept(RoomId.ToString(), Context.ConnectionId).SendAsync("CheckMessages");
        }
    }
}
