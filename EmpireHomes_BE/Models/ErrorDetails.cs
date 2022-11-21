using System.Text.Json;

namespace EmpireHomes_BE.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
