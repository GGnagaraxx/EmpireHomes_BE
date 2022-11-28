using System.ComponentModel.DataAnnotations;

namespace EmpireHomes_BE.Models.DTOs
{
    public class BlogRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public IFormFile ImgFile { get; set; }
        public string Link { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
    }
}
