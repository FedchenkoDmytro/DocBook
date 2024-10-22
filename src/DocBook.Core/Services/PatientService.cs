using AutoMapper;
using DocBook.Core.Contracts;
using DocBook.Core.Exceptions;
using DocBook.Core.Models.DTOs;
using DocBook.Core.Models.DTOs.Doctor;
using DocBook.Core.Models.DTOs.Patient;
using DocBook.Core.Models.Responses;
using DocBook.Data.Contracts;
using DocBook.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DocBook.Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IDocBookDbContext _context;
        private readonly ILogger<PatientService> _logger;
        IMapper _mapper;

        public PatientService(IDocBookDbContext context, IMapper mapper, ILogger<PatientService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        // 1. Retrieve a list of doctors with their working hours
        public async Task<IEnumerable<DoctorHoursDTO>> GetDoctorsWithWorkingHoursAsync()
        {
            _logger.LogInformation("Retrieving doctors with working hours.");

            var result = await _context.Doctors
                .Include(d => d.WorkingHours)
                .ToListAsync();

            // Map the result to a list of DoctorDTO objects
            var doctorDTOs = _mapper.Map<List<DoctorHoursDTO>>(result);
            return doctorDTOs;
        }

        // 2. Retrieve a list of booked appointment slots for a specific doctor for a given time period
        // Bookings made by the currently logged-in patient should be marked and include a booking identifier
        public async Task<IEnumerable<AppointmentDTO>> GetBookedAppointmentSlotsAsync(string doctorId, DateTime startDate, DateTime endDate, string patientId)
        {
            _logger.LogInformation("Retrieving booked appointment slots.");

            var appointments = await _context.Appointments
                .Where(a => a.DoctorId == doctorId && a.StartDateTime >= startDate && a.EndDateTime <= endDate)
                .Select(a => new AppointmentDTO
                {
                    AppointmentId = a.Id,
                    StartDateTime = a.StartDateTime,
                    EndDateTime = a.EndDateTime,
                    PatientId = a.PatientId,
                    IsBookedByCurrentPatient = a.PatientId == patientId // Mark if the current patient booked this slot
                })
                .ToListAsync();

            return appointments;
        }

        // 3. Book an available appointment slot
        public async Task<BookAppointmentResponse> BookAppointmentAsync(string patientId, BookAppointmentDTO dto)
        {
            _logger.LogInformation("Booking an appointment.");

            // Check if the requested time falls within the doctor's working hours
            var workingHours = await _context.WorkingHours
                .FirstOrDefaultAsync(w => w.DoctorId == dto.DoctorId && w.DayOfWeek == dto.StartDateTime.DayOfWeek);

            if (workingHours == null ||
                dto.StartDateTime.TimeOfDay < workingHours.StartTime ||
                dto.EndDateTime.TimeOfDay > workingHours.EndTime)
            {
                // Throw an exception with a message explanation if the time slot is outside the working hours
                throw new AppointmentBookingException("The requested time slot is outside the doctor's working hours.");
            }

            // Check if the slot is already booked
            var isSlotBooked = await _context.Appointments
                .AnyAsync(a => a.DoctorId == dto.DoctorId && a.StartDateTime == dto.StartDateTime);

            if (isSlotBooked)
            {
                // Throw an exception with a message explanation if the slot is already booked
                throw new AppointmentBookingException("The requested time slot is already booked. From");
            }

            var appointment = _mapper.Map<Appointment>(dto);
            appointment.PatientId = patientId;

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return new BookAppointmentResponse()
            {
                Message = "Appointment booked successfully",
                StatusCode = 200,
                appointmentID = appointment.Id
            };
        }

        // 4. Cancel a booked appointment
        public async Task<bool> CancelAppointmentAsync(string patientId, int appointmentId)
        {
            _logger.LogInformation("Cancelling an appointment.");

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == appointmentId && a.PatientId == patientId);

            if (appointment == null)
            {
                return false; // Appointment not found or not owned by the patient
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
