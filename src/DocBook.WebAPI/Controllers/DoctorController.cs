using DocBook.Core.Contracts;
using DocBook.Core.Models;
using DocBook.Core.Models.DTOs.Doctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocBook.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Role.Doctor)]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        /// <summary>
        /// 1. Retrieve a list of their upcoming appointments
        /// </summary>
        /// <returns></returns>
        // GET: api/doctor/appointments
        [HttpGet("appointments")]
        public async Task<IActionResult> GetUpcomingAppointments()
        {
            var doctorId = User.FindFirst("uid")?.Value;  // Assuming the doctor's ID is stored as a claim
            var appointments = await _doctorService.GetUpcomingAppointmentsAsync(doctorId);

            return Ok(appointments);
        }

        /// <summary>
        /// 2. Modify an appointment slot
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        // PUT: api/doctor/appointments/{appointmentId}
        [HttpPut("appointments/{appointmentId}")]
        public async Task<IActionResult> ModifyAppointment(int appointmentId, [FromBody] ModifyAppointmentDTO dto)
        {
            var doctorId = User.FindFirst("uid")?.Value;
            var success = await _doctorService.ModifyAppointmentAsync(doctorId, appointmentId, dto.NewStartDateTime, dto.NewEndDateTime);

            if (!success)
            {
                return BadRequest("Unable to modify the appointment slot. It may overlap with another appointment or not exist.");
            }

            return Ok("Appointment slot modified successfully.");
        }

        /// <summary>
        /// 3. Cancel an appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        // DELETE: api/doctor/appointments/{appointmentId}
        [HttpDelete("appointments/{appointmentId}")]
        public async Task<IActionResult> CancelAppointment(int appointmentId)
        {
            var doctorId = User.FindFirst("uid")?.Value;

            // Check if the appointment exists and is already canceled
            var success = await _doctorService.RemoveAppointmentAsync(doctorId, appointmentId);

            if (!success)
            {
                return BadRequest("Unable to cancel the appointment. It may not exist or has already been canceled.");
            }

            return Ok("Appointment canceled successfully.");
        }
    }
}
