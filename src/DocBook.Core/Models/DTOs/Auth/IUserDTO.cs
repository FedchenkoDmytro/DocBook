namespace DocBook.Core.Models.DTOs.Auth
{
    public interface IUserDTO
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string Role { get; set; }

        // Only for Doctor
        public string Specialization { get; set; } // This field will be used only for Doctor
    }
}
