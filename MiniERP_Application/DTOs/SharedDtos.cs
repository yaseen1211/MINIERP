using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP_Application.DTOs
{
    public class SpResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        [NotMapped]
        public object? Data { get; set; }
    }
}
