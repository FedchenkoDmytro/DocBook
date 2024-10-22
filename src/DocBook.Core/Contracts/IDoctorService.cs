using DocBook.Data.Entities;

namespace DocBook.Core.Contracts
{
    public interface IDoctorService
    {
        Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync(string doctorId);
        Task<bool> ModifyAppointmentAsync(string doctorId, int appointmentId, DateTime newStartDateTime, DateTime newEndDateTime);
        Task<bool> RemoveAppointmentAsync(string doctorId, int appointmentId);
    }
}
