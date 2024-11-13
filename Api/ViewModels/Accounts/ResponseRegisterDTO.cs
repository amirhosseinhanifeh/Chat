using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.ViewModels.Accounts
{
    public class ResponseRegisterDTO
    {
        [Required]
        public string Mobile { get; set; }

    }
    public class ResponseVerifyDTO
    {
        public string Mobile { get; set; }
        public string Code { get; set; }
    }

}
