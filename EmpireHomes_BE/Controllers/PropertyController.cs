using EmpireHomes_BE.Controllers.Mappers;
using EmpireHomes_BE.Controllers.Services;
using EmpireHomes_BE.Controllers.Services.Azure;
using EmpireHomes_BE.Models;
using EmpireHomes_BE.Models.DTOs;
using EmpireHomes_BE.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpireHomes_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyRepo propertyRepo;
        private readonly PropertyService propertyService;
        private readonly PropertyMapper propertyMapper;
        private readonly ILogger _logger;

        public PropertyController(DataContext dbContext, IBlobStorage storage, IConfiguration iConfig, ILogger<PropertyController> logger)
        {
            propertyRepo = new PropertyRepo(dbContext);
            propertyService = new PropertyService();
            propertyMapper = new PropertyMapper(propertyService, storage, iConfig);
            _logger = logger;
        }



        // GET: api/<PropertyController>
        [HttpGet]
        public async Task<ActionResult<List<Property>>> Get()
        {
            List<Property> properties = await propertyRepo.GetAll();

            if(properties== null || properties.Count == 0)
            {
                return NotFound();
            }

            return Ok(properties);
        }



        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> Get(int id)
        {
            
            Property? property = await propertyRepo.GetById(id);
            if(property==null)
            {
                _logger.LogWarning("Property with {id} not Found", id);
                return NotFound();
            }

            return Ok(property);
        }

        
        // POST api/<PropertyController>
        [HttpPost]
        public async Task<ActionResult<List<Property>>> Post([FromForm] PropertyRequest propertyReq)
        {

            Property property = await propertyMapper.ReqToProperty(propertyReq);
            propertyRepo.Add(property);
            propertyRepo.Save();

            List<Property> properties = await propertyRepo.GetAll();

            if (properties == null || properties.Count == 0)
            {
                return NotFound("Property List is empty or null");
            }

            return Ok(properties);
        }
    }
}
