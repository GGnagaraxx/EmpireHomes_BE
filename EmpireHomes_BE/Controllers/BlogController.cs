using EmpireHomes_BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpireHomes_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public BlogController(DataContext dbContext, ILogger<BlogController> logger)
        {
            _context = dbContext;
            _logger = logger;
        }

        // GET: api/<PropertyController>
        [HttpGet]
        public async Task<ActionResult<List<Blog>>> Get()
        {
            return Ok(await _context.Blogs.ToListAsync());
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> Get(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                _logger.LogWarning("GET ERROR: Blog ID {id} Not Found", id);
                return BadRequest("Blog Not Found.");
            }
            return Ok();
        }

        // POST api/<PropertyController>
        [HttpPost]
        public async Task<ActionResult<List<Blog>>> PostBlog([FromBody] Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return Ok(await _context.Blogs.ToListAsync());
        }

    }
}
