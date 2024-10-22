using System.ComponentModel.DataAnnotations;

namespace DocBook.Core.Models.DTOs.Auth
{
    public class ApiUserDTO : LoginDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? Role { get; set; }
    }
}
