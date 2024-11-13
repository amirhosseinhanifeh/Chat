using Mozer.DataAccess.Common.Repositories.Abstraction;
using Mozer.Models.Accounts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.DataAccess.Users.Abstraction
{
    public interface IUserRepository: IRepository<UserModel>
    {

    }
}
