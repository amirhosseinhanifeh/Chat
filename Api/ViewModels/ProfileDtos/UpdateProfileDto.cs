using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.ViewModels.ProfileDtos
{
    public class UpdateProfileDto
    {
        public IFormFile Image{ get; set; }
    }
}
