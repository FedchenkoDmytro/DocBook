using DocBook.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace DocBook.Core.Models.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public string PatientId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public bool IsBookedByCurrentPatient { get; set; } // Marks whether the slot was booked by the current patient
    }
}
