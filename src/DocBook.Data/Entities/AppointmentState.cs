namespace DocBook.Data.Entities
{
    public enum AppointmentState
    {
        Pending,   // Appointment is requested but not yet confirmed
        Approved,  // Appointment is confirmed and approved
        Canceled   // Appointment is canceled
    }
}
