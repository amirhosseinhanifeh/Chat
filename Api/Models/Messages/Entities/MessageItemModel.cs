using Mozer.Consts;
using Mozer.Models.Accounts.Entities;
using Mozer.Models.Common.Entities;
using Mozer.Models.Messages.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Messages.Entities
{
    [Table("MessageItems", Schema = ModelConsts.Messages)]
    public class MessageItemModel : GenericModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string  Text { get; set; }

        [Required]
        public MessageTypeEnum MessageType { get; set; }

        public bool IsRead { get; set; }
        public Guid? SenderId { get; set; }

        public UserModel Sender { get; set; }

        public Guid MessageId { get; set; }

        public MessageModel Message { get; set; }
        public ICollection<MessageItemActionModel> MessageItemActions { get; set; }
    }
}
