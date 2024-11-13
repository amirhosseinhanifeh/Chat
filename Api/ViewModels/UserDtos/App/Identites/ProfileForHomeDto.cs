using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.ViewModels.UserDtos.App
{
    public class ProfileForHomeDto: UserListForHomeDto
    {
        public Guid? MessageId { get; set; }
        public bool IsBlock { get; set; }
    }
}
