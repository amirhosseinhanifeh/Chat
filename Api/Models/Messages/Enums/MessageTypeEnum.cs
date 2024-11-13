using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Models.Messages.Enums
{
    public enum MessageTypeEnum
    {
        [Display(Name = "متن")]
        Text = 0,
        [Display(Name = "صدا")]
        Sound = 1,
        [Display(Name = "ویدیو")]
        Video = 2

    }
}
