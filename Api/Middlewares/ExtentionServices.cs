using Microsoft.Extensions.DependencyInjection;
using Mozer.Business.Account.Abstraction;
using Mozer.Business.Account.Implementation;
using Mozer.Business.Message.Abstraction;
using Mozer.Business.Message.Implementation;
using Mozer.Business.Profile.Abstraction;
using Mozer.Business.Profile.Implementation;
using Mozer.Business.Relation.Abstraction;
using Mozer.Business.Relation.Implementation;
using Mozer.Business.Upload.Abstraction;
using Mozer.Business.Upload.Implementation;
using Mozer.Business.User.Abstraction;
using Mozer.Business.User.Implementation;
using Mozer.DataAccess.Common.Abstraction;
using Mozer.DataAccess.Common.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Middlewares
{
    public static class ExtentionServices
    {
        public static void AddBusinessServices(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IRegisterService, RegisterService>();
            serviceProvider.AddScoped<IMessageService, MessageService>();
            serviceProvider.AddScoped<IProfileService, ProfileService>();
            serviceProvider.AddScoped<IUserService, UserService>();
            serviceProvider.AddScoped<IUploadService, UploadService>();
            serviceProvider.AddScoped<IRelationService, RelationService>();
        }

        public static void AddRepositoryServices(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
