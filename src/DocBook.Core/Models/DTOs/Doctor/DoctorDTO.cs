using System.ComponentModel.DataAnnotations;
using DocBook.Core.Models.DTOs.Auth;

namespace DocBook.Core.Models.DTOs.Doctor
{
    public class DoctorDTO : ApiUserDTO
    {
        public string Id { get; set; }

        [MaxLength(100)]
        public string? Specialization { get; set; }

        public IEnumerable<AppointmentDTO>? Appointments { get; set; }
        public IEnumerable<WorkingHoursDTO>? WorkingHours { get; set; }
    }
}
