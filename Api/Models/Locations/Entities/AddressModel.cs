using Mozer.Models.Accounts.Entities;
using Mozer.Models.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Locations.Entities
{
    [Table("Addresses", Schema = "Locations")]
    public class AddressModel:GenericModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsSelected { get; set; }
        public Guid UserId { get; set; }
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public CityModel City { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserModel User{ get; set; }


    }
}
