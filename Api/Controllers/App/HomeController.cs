using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mozer.Business.User.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Controllers.App
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetHomePage()
        {
            var name =User.Identity.Name;
            return Ok(await _userService.GetUsersForApp(Guid.Parse(name)));
        }
    }
}
