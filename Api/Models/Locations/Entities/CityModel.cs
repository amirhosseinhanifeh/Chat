using Mozer.Consts;
using Mozer.Models.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Locations.Entities
{
    [Table("Cities",Schema = ModelConsts.Locations)]
    public class CityModel:GenericModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int ProvinceId { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        public ProvinceModel Province { get; set; }
    }
}
