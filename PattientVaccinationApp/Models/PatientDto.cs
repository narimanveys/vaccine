using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PattientVaccinationApp.Core.Enums;
using PattientVaccinationApp.CustomValidators;

namespace PattientVaccinationApp.Models
{
    public class PatientDto
    {
        #region Properties

        public int Id { get; set; }

        [Required(ErrorMessage = "Вы не ввели Фамилию пациента")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина фамилии должна быть от 2 до 20")]
        [MaxLength(20)]
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "Длина отчества должна быть от 2 до 20")]
        [MaxLength(20)]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Вы не ввели Имя пациента")]
        [StringLength(20, ErrorMessage = "Длина имени должна быть от 2 до 20")]
        [MaxLength(20)]
        [Display(Name = "Имя")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Укажите пожалуйста дату рождения пациента")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Выберите пожалуйста пол пациента")]
        [MustBeSelected(ErrorMessage = "Необходимо выбрать пол пациента")]
        [Display(Name = "Пол")]
        public GenderType Gender { get; set; }

        [Required(ErrorMessage = "Вы не ввели СНИЛС пациента")]
        [MaxLength(50)]
        [Display(Name = "СНИЛС")]
        public string SNILS { get; set; }

        public virtual ICollection<VaccinationDto> Vaccinations { get; set; }

        #endregion
    }
}