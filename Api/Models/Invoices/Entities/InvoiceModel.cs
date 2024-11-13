using Mozer.Consts;
using Mozer.Models.Accounts.Entities;
using Mozer.Models.Common.Entities;
using Mozer.Models.Invoices.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Invoices.Entities
{
    [Table("Invoices", Schema = ModelConsts.Invoices)]
    public class InvoiceModel:GenericModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Guid UserId { get; set; }

        public InvoiceTypeEnum InvoiceType { get; set; }

        public int TotalAmount { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserModel User { get; set; }

        [InverseProperty("Invoice")]
        public ICollection<InvoiceItemModel> InvoiceItems { get; set; }
    }
}
