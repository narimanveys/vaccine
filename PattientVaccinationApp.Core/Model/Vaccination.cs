using System;
using System.ComponentModel.DataAnnotations;
using PattientVaccinationApp.Core.Enums;

namespace PattientVaccinationApp.Core.Model
{
    public class Vaccination : EntityBase
    {
        #region Properties

        [Required]
        public VaccineTypes Vaccine { get; set; }

        public bool IsVaccinationAllowed { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        #endregion
    }
}