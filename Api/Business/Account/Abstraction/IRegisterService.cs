using Mozer.ViewModels.Accounts;
using Mozer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mozer.Business.Account.Abstraction
{
    public interface IRegisterService
    {
        Task<ResultViewModel<string>> RegisterUser(ResponseRegisterDTO model, CancellationToken cancellationToken);
        Task<ResultViewModel<(string,Guid)>> RegisterByPass(RegisterByPassDto model, CancellationToken cancellationToken);
    }
}
