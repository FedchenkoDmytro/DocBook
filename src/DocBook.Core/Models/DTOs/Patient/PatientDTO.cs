using DocBook.Core.Models.DTOs.Auth;
using DocBook.Data.Entities;

namespace DocBook.Core.Models.DTOs.Patient
{
    public class PatientDTO : ApiUserDTO
    {
        public IEnumerator<AppointmentDTO>? Appointments { get; set; }
    }
}
