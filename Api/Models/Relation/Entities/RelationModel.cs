using Mozer.Consts;
using Mozer.Models.Accounts.Entities;
using Mozer.Models.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Relation.Entities
{
    [Table("Relations", Schema = ModelConsts.Relations)]
    public class RelationModel : GenericModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public Guid? FriendId { get; set; }
        public UserModel Friend { get; set; }
        public RelationTypeEnum RelationType { get; set; }
    }
    public enum RelationTypeEnum
    {
        Friend = 0,
        Block = 1,
        Report = 2,

    }
}
