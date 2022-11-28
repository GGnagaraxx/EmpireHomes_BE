using System.ComponentModel.DataAnnotations;

namespace EmpireHomes_BE.Models.DTOs
{
    public class ApplicationRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
        public string IdType { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
    }
}
