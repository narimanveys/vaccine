using AutoMapper;
using PattientVaccinationApp.Core.Model;
using PattientVaccinationApp.Models;

namespace PattientVaccinationApp
{
    public class AutomapperProfile : Profile
    {
        #region Constructors

        public AutomapperProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();
            CreateMap<Vaccination, VaccinationDto>();
            CreateMap<VaccinationDto, Vaccination>();
        }

        #endregion
    }
}