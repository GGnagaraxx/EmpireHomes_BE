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
    public class BlogController : ControllerBase
    {
        private readonly BlogRepo blogRepo;
        private readonly BlogService blogService;
        private readonly BlogMapper blogMapper;
        private readonly ILogger _logger;

        public BlogController(DataContext dbContext, IBlobStorage storage, IConfiguration iConfig, ILogger<BlogController> logger)
        {
            blogRepo = new BlogRepo(dbContext);
            blogService = new BlogService();
            blogMapper = new BlogMapper(blogService, storage, iConfig);
            _logger = logger;
        }



        // GET: api/<BlogController>
        [HttpGet]
        public async Task<ActionResult<List<Blog>>> Get()
        {
            List<Blog> blogs = await blogRepo.GetAll();

            if (blogs == null || blogs.Count == 0)
            {
                return NotFound();
            }

            return Ok(blogs);
        }



        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> Get(int id)
        {

            Blog? blog = await blogRepo.GetById(id);
            if (blog == null)
            {
                _logger.LogWarning("blog with {id} not Found", id);
                return NotFound();
            }

            return Ok(blog);
        }


        // POST api/<BlogController>
        [HttpPost]
        public async Task<ActionResult<List<Blog>>> Post([FromForm] BlogRequest blogReq)
        {

            Blog blog = await blogMapper.ReqToBlog(blogReq);
            blogRepo.Add(blog);
            blogRepo.Save();

            List<Blog> blogs = await blogRepo.GetAll();

            if (blogs == null || blogs.Count == 0)
            {
                return NotFound("blog List is empty or null");
            }

            return Ok(blogs);
        }
    }
}
