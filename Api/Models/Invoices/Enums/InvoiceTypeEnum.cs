using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Invoices.Enums
{
    public enum InvoiceTypeEnum
    {
        [Display(Name="پرداخت شده")]
        IsPayed,
        [Display(Name ="در انتظار پرداخت")]
        Pending,
        
    }
}
