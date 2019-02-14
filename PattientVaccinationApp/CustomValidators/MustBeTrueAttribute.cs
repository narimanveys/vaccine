using System.ComponentModel.DataAnnotations;

namespace PattientVaccinationApp.CustomValidators
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        #region Methods

        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }

        #endregion
    }
}