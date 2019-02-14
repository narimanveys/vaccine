using System.ComponentModel.DataAnnotations;

namespace PattientVaccinationApp.CustomValidators
{
    public class MustBeSelectedAttribute : ValidationAttribute
    {
        #region Methods

        public override bool IsValid(object value)
        {
            return (int)value != 0;
        }

        #endregion
    }
}