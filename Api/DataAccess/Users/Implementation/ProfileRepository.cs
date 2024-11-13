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
    public class ProfileRepository: Repository<ProfileModel>, IProfileRepository
    {
        public ProfileRepository(MozerContext context) : base(context)
        {

        }

    }
}
