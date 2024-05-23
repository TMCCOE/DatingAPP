using DatingAPP.Domain.Entities;
using DationgAppServices.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace API.Controllers
{
    [Route("api/users")]   //localhost5000/api/users?id=1
    [ApiController]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("all", Name = nameof(GetAllUsersAsync))]
        [ProducesResponseType(typeof(IEnumerable<AppUser>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var (status, entities) = await _userService.GetAllUsersAsync();
            if (entities.Count() == 0) return NotFound();
            return Ok(entities);
        }

    }
}
