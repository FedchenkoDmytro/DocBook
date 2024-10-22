namespace DocBook.Data.Entities
{
    public class Patient : ApiUser
    {
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
