namespace DocBook.Core.Models.DTOs.Auth
{
    public class RegisterUserDTO : IUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Patient";

        // Only for Doctor
        public string? Specialization { get; set; } // This field will be used only for Doctor
        public IEnumerable<WorkingHoursDTO>? WorkingHours { get; set; } // This field will be used only for Doctor
    }
}
