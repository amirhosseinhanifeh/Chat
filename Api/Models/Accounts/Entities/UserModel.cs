using Microsoft.EntityFrameworkCore;
using Mozer.Consts;
using Mozer.Models.Accounts.Enums;
using Mozer.Models.Common.Entities;
using Mozer.Models.Locations.Entities;
using Mozer.Models.Messages.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Accounts.Entities
{
    [Table("Users", Schema = ModelConsts.Identities)]
    [Index(nameof(UserName), IsUnique =true)]
    [Index(nameof(Email), IsUnique =true)]
    public class UserModel: GenericModel
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public UserStateEnum UserState { get; set; }

        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public RoleModel Role { get; set; }

        public ProfileModel Profile { get; set; }

        public ICollection<AddressModel> Address{ get; set; }
        [InverseProperty("Sender")]
        public ICollection<MessageModel> Messages{ get; set; }

        [InverseProperty("User")]
        public ICollection<Relation.Entities.RelationModel> UserRelations{ get; set; }

        [InverseProperty("Friend")]
        public ICollection<Relation.Entities.RelationModel> FriendRelations{ get; set; }

    }
}
