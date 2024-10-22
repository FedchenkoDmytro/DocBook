using NSubstitute;
using AutoMapper;
using DocBook.Core.Exceptions;
using DocBook.Core.Models.DTOs.Doctor;
using DocBook.Core.Models.DTOs.Patient;
using DocBook.Core.Services;
using DocBook.Data.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using DocBook.Data.Contracts;

namespace DocBook.Core.Tests
{
    [TestClass]
    public class PatientServiceTests
    {
        private Mock<IDocBookDbContext> _mockContext = null!;
        private IMapper _mockMapper = null!;
        private ILogger<PatientService> _mockLogger = null!;
        private PatientService _patientService = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockContext = new Mock<IDocBookDbContext>();
            _mockMapper = Substitute.For<IMapper>();
            _mockLogger = Substitute.For<ILogger<PatientService>>();
            _patientService = new PatientService(_mockContext.Object, _mockMapper, _mockLogger);
        }

        [TestMethod]
        public async Task GetDoctorsWithWorkingHoursAsync_ShouldReturnDoctorHoursDTOs()
        {
            // Arrange
            var doctors = new List<Doctor>
            {
                new Doctor { Id = "1", WorkingHours = new List<WorkingHours>() }
            };

            _mockContext.Setup(x => x.Doctors).ReturnsDbSet(doctors);
            _mockMapper.Map<List<DoctorHoursDTO>>(Arg.Any<List<Doctor>>()).Returns(new List<DoctorHoursDTO>());

            // Act
            var result = await _patientService.GetDoctorsWithWorkingHoursAsync();

            // Assert
            Assert.IsNotNull(result);
            _mockLogger.Received(1).LogInformation("Retrieving doctors with working hours.");
        }

        [TestMethod]
        public async Task GetBookedAppointmentSlotsAsync_ShouldReturnAppointmentDTOs()
        {
            // Arrange
            var appointments = new List<Appointment>
            {
                new Appointment { Id = 1, DoctorId = "1", StartDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddHours(1), PatientId = "1" }
            };

            _mockContext.Setup(x => x.Appointments).ReturnsDbSet(appointments);

            // Act
            var result = await _patientService.GetBookedAppointmentSlotsAsync("1", DateTime.Now, DateTime.Now.AddDays(1), "1");

            // Assert
            Assert.IsNotNull(result);
            _mockLogger.Received(1).LogInformation("Retrieving booked appointment slots.");
        }

        [TestMethod]
        [ExpectedException(typeof(AppointmentBookingException))]
        public async Task BookAppointmentAsync_ShouldThrowException_WhenOutsideWorkingHours()
        {
            // Arrange
            var dto = new BookAppointmentDTO { DoctorId = "1", StartDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddHours(1) };
            _mockContext.Setup(x => x.WorkingHours).ReturnsDbSet(new List<WorkingHours>
            {
                new WorkingHours { DoctorId = "1", DayOfWeek = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(17) },
                new WorkingHours { DoctorId = "1", DayOfWeek = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(17) }
            });
            _mockContext.Setup(x => x.WorkingHours).ReturnsDbSet(new List<WorkingHours>());

            // Act
            await _patientService.BookAppointmentAsync("1", dto);
        }

        [TestMethod]
        [ExpectedException(typeof(AppointmentBookingException))]
        public async Task BookAppointmentAsync_ShouldThrowException_WhenSlotAlreadyBooked()
        {
            // Arrange
            var dto = new BookAppointmentDTO { DoctorId = "1", StartDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddHours(1) };
            var workingHour = new WorkingHours { DoctorId = "1", DayOfWeek = DateTime.Now.DayOfWeek, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(17) };
            _mockContext.Setup(x => x.WorkingHours).ReturnsDbSet(new List<WorkingHours> { workingHour });
            _mockContext.Setup(x => x.Appointments).ReturnsDbSet(new List<Appointment> { new Appointment { DoctorId = "1", StartDateTime = dto.StartDateTime, EndDateTime = dto.EndDateTime } });

            // Act
            await _patientService.BookAppointmentAsync("1", dto);
        }

        [TestMethod]
        public async Task BookAppointmentAsync_ShouldReturnSuccessResponse_WhenBookingIsValid()
        {
            // Arrange
            var dto = new BookAppointmentDTO { DoctorId = "1", StartDateTime = DateTime.Now, EndDateTime = DateTime.Now.AddHours(1) };
            var workingHour = new WorkingHours { DoctorId = "1", DayOfWeek = DateTime.Now.DayOfWeek, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(17) };

            _mockContext.Setup(x => x.WorkingHours).ReturnsDbSet(new List<WorkingHours> { workingHour });
            _mockContext.Setup(x => x.Appointments).ReturnsDbSet(new List<Appointment>());
            _mockMapper.Map<Appointment>(Arg.Any<BookAppointmentDTO>()).Returns(new Appointment { Id = 1 });

            // Act
            var result = await _patientService.BookAppointmentAsync("1", dto);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            _mockLogger.Received(1).LogInformation("Booking an appointment.");
        }

        [TestMethod]
        public async Task CancelAppointmentAsync_ShouldReturnTrue_WhenAppointmentIsCanceled()
        {
            // Arrange
            var appointment = new Appointment { Id = 1, PatientId = "1" };
            _mockContext.Setup(x => x.Appointments).ReturnsDbSet(new List<Appointment> { appointment });

            // Act
            var result = await _patientService.CancelAppointmentAsync("1", 1);

            // Assert
            Assert.IsTrue(result);
            _mockLogger.Received(1).LogInformation("Cancelling an appointment.");
        }

        [TestMethod]
        public async Task CancelAppointmentAsync_ShouldReturnFalse_WhenAppointmentNotFound()
        {
            // Arrange
            _mockContext.Setup(x => x.Appointments).ReturnsDbSet(new List<Appointment>());

            // Act
            var result = await _patientService.CancelAppointmentAsync("1", 1);

            // Assert
            Assert.IsFalse(result);
            _mockLogger.Received(1).LogInformation("Cancelling an appointment.");
        }
    }
}