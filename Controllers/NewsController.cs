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
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var news = await _newsService.Get(id);

            return Ok(news);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(News news)
        {
            var created = await _newsService.Create(news);

            return Ok(created);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<News>> Remove(Guid id)
        {
            var news = await _newsService.Remove(id);
            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, News news)
        {
            if (id != news.Id)
            {
                return BadRequest();
            }
            await _newsService.Update(news);
            return NoContent();
        }
    }
}
