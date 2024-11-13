using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mozer.Business.Account.Abstraction;
using Mozer.ViewModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mozer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IRegisterService _registerService;

        public AccountController(IRegisterService registerService)
        {
            _registerService = registerService;
        }



        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterByPassDto model, CancellationToken cancellationToken)
        {
            var result = await _registerService.RegisterByPass(model, cancellationToken);
            return Ok(new
            {
                token = result.Object.Item1,
                userId=result.Object.Item2
            }) ;
        }
    }
}
