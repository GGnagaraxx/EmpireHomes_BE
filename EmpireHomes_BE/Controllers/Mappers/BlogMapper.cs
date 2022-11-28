using EmpireHomes_BE.Controllers.Services.Azure;
using EmpireHomes_BE.Controllers.Services;
using EmpireHomes_BE.Models.DTOs;
using EmpireHomes_BE.Models;

namespace EmpireHomes_BE.Controllers.Mappers
{
    public class BlogMapper
    {

        private readonly BlogService blogService;
        private readonly IBlobStorage storage;
        private readonly string connectionString;
        private readonly string container;

        public BlogMapper(BlogService blogService, IBlobStorage storage, IConfiguration iConfig)
        {
            this.blogService = blogService;
            this.storage = storage;
            connectionString = iConfig.GetValue<string>("StorageConnection");
            container = iConfig.GetValue<string>("MyConfig:ContainerName");
        }
        public async Task<Blog> ReqToBlog(BlogRequest blogDTO)
        {

            Blog newBlog = new Blog
            {
                Id = blogDTO.Id,
                Title = blogDTO.Title,
                Date = blogDTO.Date,
                Summary = blogDTO.Summary,

            };

            newBlog.ImgUrl = await blogService.uploadImage(blogDTO.ImgFile, storage, connectionString, container);

            return newBlog;
        }
    }
}
