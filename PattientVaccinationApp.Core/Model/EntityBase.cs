using System.ComponentModel.DataAnnotations;

namespace PattientVaccinationApp.Core.Model
{
    public class EntityBase
    {
        #region Properties 

        [Key]
        public int Id { get; set; }

        #endregion
    }
}