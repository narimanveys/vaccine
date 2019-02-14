using System.ComponentModel;

namespace PattientVaccinationApp.Core.Enums
{
    public enum VaccineTypes
    {
        [Description("Эджерикс")]
        Эджерикс = 1,

        [Description("Вианвак")]
        Вианвак = 2,

        [Description("АКДС")]
        АКДС = 3,

        [Description("БЦЖ")]
        БЦЖ = 4
    }
}