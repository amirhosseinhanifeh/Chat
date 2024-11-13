using Mozer.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Accounts.Entities
{
    [Table("Profiles", Schema = ModelConsts.Identities)]
    public class ProfileModel
    {
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string ConnectionId { get; set; }
        public UserModel User { get; set; }

    }
}
