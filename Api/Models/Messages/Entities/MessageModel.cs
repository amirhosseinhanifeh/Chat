using Mozer.Consts;
using Mozer.Models.Accounts.Entities;
using Mozer.Models.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Messages.Entities
{
    [Table("Messages", Schema = ModelConsts.Messages)]
    public class MessageModel:GenericModel
    {
        [Key]
        public Guid Id { get; set; }
        public string RoomCode { get; set; }
        public Guid SenderId { get; set; }
        public Guid? ReciverId { get; set; }
        public UserModel Sender { get; set; }
        public UserModel Reciver { get; set; }
        public ICollection<MessageItemModel> MessageItems { get; set; }
        public ICollection<MessageActionModel> MessageActions { get; set; }

    }
}
