using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Models;
using NewsPortal.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.Get(id);

            return Ok(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(User user)
        {
            var created = await _userService.Create(user);

            return Ok(created);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<User>> Remove(Guid id)
        {
            var user = await _userService.Remove(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            await _userService.Update(user);
            return NoContent();
        }
    }
}
