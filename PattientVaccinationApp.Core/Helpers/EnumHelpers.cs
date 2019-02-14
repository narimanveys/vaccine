using System;
using System.ComponentModel;
using System.Linq;

namespace PattientVaccinationApp.Core.Helpers
{
    public static class EnumHelpers
    {
        #region Methods

        public static string GetDescriptionFromEnumValue(Enum value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        #endregion
    }
}