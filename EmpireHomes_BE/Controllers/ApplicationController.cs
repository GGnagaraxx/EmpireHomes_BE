using EmpireHomes_BE.Controllers.Mappers;
using EmpireHomes_BE.Controllers.Services;
using EmpireHomes_BE.Controllers.Services.Azure;
using EmpireHomes_BE.Models;
using EmpireHomes_BE.Models.DTOs;
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
        private readonly ApplicationMapper mapper;
        private readonly ApplicationService service;

        public ApplicationController(DataContext dbContext, IBlobStorage storage, IConfiguration iConfig)
        {
            service = new ApplicationService();
            mapper = new ApplicationMapper(service, storage, iConfig);
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
        public async Task<ActionResult<List<Application>>> Post([FromBody] ApplicationRequest applicationReq)
        {
            Application application = mapper.ReqToApplication(applicationReq);
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return Ok(await _context.Applications.ToListAsync());
        }
    }
}
