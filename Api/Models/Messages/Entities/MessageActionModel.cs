using Microsoft.EntityFrameworkCore;
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
    [Table("MessageActions", Schema = ModelConsts.Messages)]
    [Index(new string[] { nameof(UserId),nameof(MessageId),nameof(MessageAction) })]
    public class MessageActionModel : GenericModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Guid? UserId { get; set; }

        public Guid MessageId { get; set; }

        public MessageActionsEnum MessageAction { get; set; }

        [ForeignKey(nameof(MessageId))]
        public MessageModel Message { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserModel User { get; set; }
    }
}
