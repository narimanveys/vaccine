using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PattientVaccinationApp.Core.Enums;

namespace PattientVaccinationApp.Core.Model
{
    public class Patient : EntityBase
    {
        #region Properties

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public GenderType Gender { get; set; }

        [Required]
        [MaxLength(50)]
        public string SNILS { get; set; }

        public virtual ICollection<Vaccination> Vaccinations { get; set; }

        #endregion
    }
}