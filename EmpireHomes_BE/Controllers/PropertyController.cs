using EmpireHomes_BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpireHomes_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public PropertyController(DataContext dbContext, ILogger<PropertyController> logger)
        {
            _context = dbContext;
            _logger = logger;
        }

        // GET: api/<PropertyController>
        [HttpGet]
        public async Task<ActionResult<List<Property>>> Get()
        {
            return Ok(await _context.Properties.ToListAsync());
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> Get(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if(property == null)
            {
                _logger.LogWarning("GET ERROR: Property ID {id} Not Found", id);
                return BadRequest("Property Not Found.");
            }
            return Ok(property);
        }

        // POST api/<PropertyController>
        [HttpPost]
        public async Task<ActionResult<List<Property>>> Post([FromBody] Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            return Ok(await _context.Properties.ToListAsync());
        }

    }
}
