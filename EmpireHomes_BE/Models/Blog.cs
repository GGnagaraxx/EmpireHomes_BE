using System.ComponentModel.DataAnnotations;

namespace EmpireHomes_BE.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Date { get; set; } = string.Empty;
        [Required]
        public string ImgUrl { get; set; } = string.Empty;
        [Required]
        public string Link { get; set; } = string.Empty;
        [Required]
        public string Summary { get; set; } = string.Empty;
    }
}
