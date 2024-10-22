using System.ComponentModel.DataAnnotations;

namespace DocBook.Data.Entities
{
    public class Doctor : ApiUser
    {
        [MaxLength(100)]
        [Required]
        public string Specialization { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<WorkingHours>? WorkingHours { get; set; }
    }
}
