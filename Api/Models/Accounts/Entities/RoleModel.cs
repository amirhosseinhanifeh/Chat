using Mozer.Consts;
using Mozer.Models.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Accounts.Entities
{
    [Table("Roles", Schema = ModelConsts.Identities)]
    public class RoleModel:GenericModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}
