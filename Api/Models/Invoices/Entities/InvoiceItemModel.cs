using Mozer.Consts;
using Mozer.Models.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Invoices.Entities
{
    [Table("InvoiceItems", Schema = ModelConsts.Invoices)]
    public class InvoiceItemModel:GenericModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? InvoiceId { get; set; }

        public int ItemAmount { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public InvoiceModel Invoice { get; set; }


    }
}
