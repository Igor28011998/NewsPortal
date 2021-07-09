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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var comment = await _commentService.Get(id);

            return Ok(comment);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(Comment comment)
        {
            var created = await _commentService.Create(comment);

            return Ok(created);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Comment>> Remove(Guid id)
        {
            var comment = await _commentService.Remove(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }
            await _commentService.Update(comment);
            return NoContent();
        }
    }
}
