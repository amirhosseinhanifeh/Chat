using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mozer.Business.Profile.Abstraction;
using Mozer.Business.User.Abstraction;
using Mozer.ViewModels.ProfileDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Controllers.App
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = Guid.Parse(User.Identity.Name);
            var pro = await _profileService.Getprofile(user, id);
            return Ok(new
            {
                profile = pro
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile([FromForm] UpdateProfileDto model)
        {
            var user = Guid.Parse(User.Identity.Name);
            await _profileService.UpdateProfile(user, model);
            return Ok(new
            {
                Status =1,
                Message = "با موفقیت ویرایش شد"
            });
        }
    }
}
