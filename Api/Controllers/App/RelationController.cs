using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mozer.Business.Relation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.Controllers.App
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RelationController : ControllerBase
    {
        private readonly IRelationService _relationService;

        public RelationController(IRelationService relationService)
        {
            _relationService = relationService;
        }
        [HttpPut("{friendId}")]
        public async Task<IActionResult> Block(Guid friendId)
        {
            var user = Guid.Parse(User.Identity.Name);
            await _relationService.SetRelation(user, friendId, Models.Relation.Entities.RelationTypeEnum.Block);
            return Ok();
        }
    }
}
