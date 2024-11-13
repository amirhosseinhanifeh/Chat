using Mozer.DataAccess.Common.Repositories.Implementation;
using Mozer.DataAccess.Users.Abstraction;
using Mozer.Models.Accounts.Entities;
using Mozer.ServiceContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.DataAccess.Users.Implementation
{
    public class UserRepository : Repository<UserModel>, IUserRepository 
    {
        public UserRepository(MozerContext context ):base(context)
        {

        }
    }
}
