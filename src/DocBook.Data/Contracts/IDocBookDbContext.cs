using DocBook.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocBook.Data.Contracts
{
    public interface IDocBookDbContext
    {
        DbSet<Patient> Patients { get; set; }
        DbSet<Doctor> Doctors { get; set; }
        DbSet<Appointment> Appointments { get; set; }
        DbSet<WorkingHours> WorkingHours { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
