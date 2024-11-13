using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.ViewModels.MessageDtos.App
{
    public class MessageItemsDto
    {
        public Guid MessageId { get; set; }
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public string ReciverName { get; set; }
        public string Avatar { get; set; }
        public string UserName { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
        public bool IsMe { get; set; }
        public bool IsRead { get; set; }
    }
}
