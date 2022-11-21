using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpireHomes_BE.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Location { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Type { get; set; } = string.Empty;
        [Required]
        public int MinPrice { get; set; }
        [Required]
        public int MaxPrice { get; set; }
        [Required]
        public int Demand { get; set; }
        [Required]
        public int Progress { get; set; }
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = string.Empty;



    }
}
