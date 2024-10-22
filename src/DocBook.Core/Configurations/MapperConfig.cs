using AutoMapper;
using DocBook.Core.Models.DTOs;
using DocBook.Core.Models.DTOs.Auth;
using DocBook.Core.Models.DTOs.Doctor;
using DocBook.Core.Models.DTOs.Patient;
using DocBook.Data.Entities;

namespace DocBook.Core.Configurations
{
    public  class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<WorkingHours, WorkingHoursDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Appointment, BookAppointmentDTO>().ReverseMap();
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Doctor, DoctorHoursDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();


            CreateMap<ApiUserDTO, ApiUser>().ReverseMap();
            CreateMap<RegisterUserDTO, Patient>().ReverseMap();
            CreateMap<RegisterUserDTO, Doctor>().ReverseMap();
        }
    }
}
