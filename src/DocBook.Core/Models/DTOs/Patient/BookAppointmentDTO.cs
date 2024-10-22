namespace DocBook.Core.Models.DTOs.Patient
{
    public class BookAppointmentDTO
    {
        public string DoctorId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
