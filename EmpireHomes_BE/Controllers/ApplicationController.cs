using EmpireHomes_BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpireHomes_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly DataContext _context;

        public ApplicationController(DataContext dbContext)
        {
            _context = dbContext;
        }

        // GET: api/<ApplicationController>
        [HttpGet]
        public async Task<ActionResult<List<Application>>> Get()
        {
            return Ok(await _context.Applications.ToListAsync());
        }

        // POST api/<ApplicationController>
        [HttpPost]
        public async Task<ActionResult<List<Application>>> Post([FromBody] Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return Ok(await _context.Applications.ToListAsync());
        }
    }
}
