using System.ComponentModel.DataAnnotations;

namespace EmpireHomes_BE.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string ContactNumber { get; set; } = string.Empty;
        [Required]
        public string Province { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
        public string IdType { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;

    }
}
