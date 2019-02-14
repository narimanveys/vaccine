using System;
using System.ComponentModel.DataAnnotations;
using PattientVaccinationApp.Core.Enums;
using PattientVaccinationApp.CustomValidators;

namespace PattientVaccinationApp.Models
{
    public class VaccinationDto
    {
        #region Properties
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать прививку")]
        [Display(Name = "Прививка")]
        [MustBeSelected(ErrorMessage = "Необходимо выбрать прививку")]
        public VaccineTypes Vaccine { get; set; }

        [Display(Name = "Наличие согласия прививку")]
        [MustBeTrue(ErrorMessage = "Согласие на прививку обязательно")]
        public bool IsVaccinationAllowed { get; set; }

        [Required(ErrorMessage = "Укажите пожалуйста дату проведения прививки")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата проведения")]
        public DateTime ReleaseDate { get; set; }

        public int PatientId { get; set; }

        public PatientDto Patient { get; set; }

        #endregion
    }
}