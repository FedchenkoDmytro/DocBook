using DocBook.Data.Confirgurations;
using DocBook.Data.Contracts;
using DocBook.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Emit;

namespace DocBook.Data
{
    public class DocBookDbContext : IdentityDbContext<ApiUser>, IDocBookDbContext
    {
        public DocBookDbContext(DbContextOptions<DocBookDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<IdentityUser>();
            var password = "password";

            // Seed data for Doctors
            var doctor1 = new Doctor
            {
                Id = "1",
                FirstName = "John",
                LastName = "Doe",
                Specialization = "Cardiologist",
                Email = "johndoe@hospital.com",
                UserName = "johndoe@hospital.com"
            };
            doctor1.PasswordHash = passwordHasher.HashPassword(doctor1, password);

            var doctor2 = new Doctor
            {
                Id = "2",
                FirstName = "Jane",
                LastName = "Smith",
                Specialization = "Dermatologist",
                Email = "janesmith@hospital.com",
                UserName = "janesmith@hospital.com"
            };
            doctor2.PasswordHash = passwordHasher.HashPassword(doctor2, password);

            modelBuilder.Entity<Doctor>().HasData(doctor1, doctor2);

            // Seed data for Patients
            var patient1 = new Patient
            {
                Id = "3",
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice@patient.com",
                UserName = "alice@patient.com"
            };
            patient1.PasswordHash = passwordHasher.HashPassword(patient1, password);

            var patient2 = new Patient
            {
                Id = "4",
                FirstName = "Bob",
                LastName = "Brown",
                Email = "bob@patient.com",
                UserName = "bob@patient.com"
            };
            patient2.PasswordHash = passwordHasher.HashPassword(patient2, password);

            modelBuilder.Entity<Patient>().HasData(patient1, patient2);

            // Seed data for WorkingHours
            modelBuilder.Entity<WorkingHours>().HasData(
                new WorkingHours
                {
                    Id = 1,
                    DoctorId = "1", // John Doe
                    DayOfWeek = DayOfWeek.Monday,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0)
                },
                new WorkingHours
                {
                    Id = 2,
                    DoctorId = "1", // John Doe
                    DayOfWeek = DayOfWeek.Tuesday,
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0)
                },
                new WorkingHours
                {
                    Id = 3,
                    DoctorId = "2", // Jane Smith
                    DayOfWeek = DayOfWeek.Wednesday,
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0)
                }
            );

            // Seed data for Appointments
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    PatientId = "3", // Alice Johnson
                    DoctorId = "1",  // John Doe
                    StartDateTime = new DateTime(2024, 10, 21, 10, 0, 0),
                    EndDateTime = new DateTime(2024, 10, 21, 11, 0, 0),
                },
                new Appointment
                {
                    Id = 2,
                    PatientId = "4", // Bob Brown
                    DoctorId = "2",  // Jane Smith
                    StartDateTime = new DateTime(2024, 10, 22, 11, 0, 0),
                    EndDateTime = new DateTime(2024, 10, 22, 12, 0, 0),
                },
                new Appointment
                {
                    Id = 3,
                    PatientId = "3", // Alice Johnson
                    DoctorId = "2",  // Jane Smith
                    StartDateTime = new DateTime(2024, 10, 23, 12, 0, 0),
                    EndDateTime = new DateTime(2024, 10, 23, 13, 0, 0),
                }
            );
        }
    }
}
