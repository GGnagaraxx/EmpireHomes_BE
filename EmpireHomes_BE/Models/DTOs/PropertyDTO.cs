using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmpireHomes_BE.Models.DTOs
{
    public class PropertyRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int Demand { get; set; }
        public int Progress { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Description { get; set; } = string.Empty;
    }

}
