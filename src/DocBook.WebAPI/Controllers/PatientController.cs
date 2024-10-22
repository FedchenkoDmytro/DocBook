using DocBook.Core.Contracts;
using DocBook.Core.Models.DTOs.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocBook.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientRepository;

        public PatientController(IPatientService patientRepository, ILogger<PatientController> logger)
        {
            _logger = logger;
            _patientRepository = patientRepository;
        }

        /// <summary>
        /// 1. Retrieve a list of doctors with their working hours
        /// </summary>
        /// <returns></returns>
        // GET: api/patient/doctors
        [HttpGet("doctors")]
        public async Task<IActionResult> GetDoctorsWithWorkingHours()
        {
            var doctors = await _patientRepository.GetDoctorsWithWorkingHoursAsync();
            return Ok(doctors);
        }

        /// <summary>
        /// 2. Retrieve a list of booked appointment slots for a specific doctor for a given time period
        // Bookings made by the currently logged-in patient should be marked and include a booking identifier
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        // GET: api/patient/doctor/{doctorId}/appointments
        [Authorize]
        [HttpGet("doctor/{doctorId}/appointments")]
        public async Task<IActionResult> GetBookedAppointments(string doctorId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var patientId = User.FindFirst("uid")?.Value; // Assuming the patient ID is stored as a claim
            var appointmentSlots = await _patientRepository.GetBookedAppointmentSlotsAsync(doctorId, startDate, endDate, patientId);
            return Ok(appointmentSlots);
        }

        /// <summary>
        /// 3. Book an available appointment slot
        /// </summary>
        /// <param name="bookAppointmentDto"></param>
        /// <returns></returns>
        // POST: api/patient/book-appointment
        [Authorize]
        [HttpPost("book-appointment")]
        public async Task<IActionResult> BookAppointment([FromBody] BookAppointmentDTO bookAppointmentDto)
        {
            var patientId = User.FindFirst("uid")?.Value;
            var success = await _patientRepository.BookAppointmentAsync(patientId, bookAppointmentDto);

            return Ok(success);
        }

        /// <summary>
        /// 4. Cancel a booked appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        // DELETE: api/patient/cancel-appointment/{appointmentId}
        [Authorize]
        [HttpDelete("cancel-appointment/{appointmentId}")]
        public async Task<IActionResult> CancelAppointment(int appointmentId)
        {
            var patientId = User.FindFirst("uid")?.Value;
            var success = await _patientRepository.CancelAppointmentAsync(patientId, appointmentId);
            if (!success)
            {
                return NotFound("Appointment not found or you are not authorized to cancel it.");
            }

            return Ok("Appointment canceled successfully.");
        }
    }
}
