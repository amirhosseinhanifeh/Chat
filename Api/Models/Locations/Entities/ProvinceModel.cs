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
    [Table("Provinces", Schema = ModelConsts.Locations)]
    public class ProvinceModel:GenericModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [InverseProperty("Province")]
        public ICollection<CityModel> Cities{ get; set; }

    }
}
