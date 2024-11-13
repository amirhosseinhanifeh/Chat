using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.ViewModels.UserDtos.App
{
    public class UserListForHomeDto
    {
        public string FullName { get; set; }
        public Guid Id { get; set; }
        public string Avatar { get; set; }
        public string UserName { get; set; }
    }
}
