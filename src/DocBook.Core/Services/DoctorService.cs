using AutoMapper;
using DocBook.Core.Contracts;
using DocBook.Data.Contracts;
using DocBook.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DocBook.Core.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDocBookDbContext _context;
        private readonly ILogger<DoctorService> _logger;
        private readonly IMapper _mapper;

        public DoctorService(IDocBookDbContext context, IMapper mapper, ILogger<DoctorService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        // 1. Retrieve a list of their upcoming appointments
        public async Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync(string doctorId)
        {
            _logger.LogInformation("Retrieving upcoming appointments for doctor with ID: {doctorId}", doctorId);

            var appointments = await _context.Appointments
                .Where(a => a.DoctorId == doctorId && a.StartDateTime > DateTime.Now)
                .OrderBy(a => a.StartDateTime)  // Sort by appointment start time
                .ToListAsync();

            _logger.LogInformation("Retrieved {count} upcoming appointments for doctor with ID: {doctorId}", appointments.Count, doctorId);

            return appointments;
        }

        // 2. Modify an appointment slot
        public async Task<bool> ModifyAppointmentAsync(string doctorId, int appointmentId, DateTime newStartDateTime, DateTime newEndDateTime)
        {
            _logger.LogInformation("Modifying appointment with ID: {appointmentId} for doctor with ID: {doctorId}", appointmentId, doctorId);

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == appointmentId && a.DoctorId == doctorId);

            if (appointment == null)
            {
                _logger.LogWarning("Appointment with ID: {appointmentId} not found or already canceled for doctor with ID: {doctorId}", appointmentId, doctorId);
                return false; // Appointment not found or already canceled
            }

            // Check if the new slot overlaps with any other appointments
            var isSlotBooked = await _context.Appointments
                .AnyAsync(a => a.DoctorId == doctorId
                               && a.StartDateTime < newEndDateTime
                               && a.EndDateTime > newStartDateTime
                               && a.Id != appointmentId);

            if (isSlotBooked)
            {
                _logger.LogWarning("New slot overlaps with another appointment for doctor with ID: {doctorId}", doctorId);
                return false; // New slot overlaps with another appointment
            }

            // Check if the new slot falls within the doctor's working hours
            var workingHours = await _context.WorkingHours
                .FirstOrDefaultAsync(w => w.DoctorId == doctorId && w.DayOfWeek == newStartDateTime.DayOfWeek);

            if (workingHours == null ||
                newStartDateTime.TimeOfDay < workingHours.StartTime ||
                newEndDateTime.TimeOfDay > workingHours.EndTime)
            {
                _logger.LogWarning("New time slot is outside of the doctor's working hours for doctor with ID: {doctorId}", doctorId);
                return false; // The new time slot is outside of the doctor's working hours
            }

            // Update the appointment with the new slot
            appointment.StartDateTime = newStartDateTime;
            appointment.EndDateTime = newEndDateTime;

            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Modified appointment with ID: {appointmentId} for doctor with ID: {doctorId}", appointmentId, doctorId);

            return true;
        }

        // 3. Cancel a patient's appointment
        public async Task<bool> RemoveAppointmentAsync(string doctorId, int appointmentId)
        {
            _logger.LogInformation("Removing appointment with ID: {appointmentId} for doctor with ID: {doctorId}", appointmentId, doctorId);

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == appointmentId && a.DoctorId == doctorId);

            if (appointment == null)
            {
                _logger.LogWarning("Appointment with ID: {appointmentId} not found or already removed for doctor with ID: {doctorId}", appointmentId, doctorId);
                return false; // Appointment not found or already removed
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Removed appointment with ID: {appointmentId} for doctor with ID: {doctorId}", appointmentId, doctorId);
            return true;
        }
    }

}
