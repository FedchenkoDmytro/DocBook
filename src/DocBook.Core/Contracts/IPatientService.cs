using DocBook.Core.Models.DTOs;
using DocBook.Core.Models.DTOs.Doctor;
using DocBook.Core.Models.DTOs.Patient;
using DocBook.Core.Models.Responses;
using DocBook.Data.Entities;

namespace DocBook.Core.Contracts
{
    public interface IPatientService
    {
        Task<IEnumerable<DoctorHoursDTO>> GetDoctorsWithWorkingHoursAsync();
        Task<IEnumerable<AppointmentDTO>> GetBookedAppointmentSlotsAsync(string doctorId, DateTime startDate, DateTime endDate, string patientId);
        Task<BookAppointmentResponse> BookAppointmentAsync(string patientId, BookAppointmentDTO dto);
        Task<bool> CancelAppointmentAsync(string patientId, int appointmentId);
    }
}
