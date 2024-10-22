using System.ComponentModel.DataAnnotations;
using DocBook.Core.Models.DTOs.Auth;

namespace DocBook.Core.Models.DTOs.Doctor
{
    public class DoctorHoursDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [MaxLength(100)]
        public string? Specialization { get; set; }

        public IEnumerable<WorkingHoursDTO>? WorkingHours { get; set; }
    }
}
