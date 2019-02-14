using System.Data.Entity;
using PattientVaccinationApp.Core.Model;

namespace PattientVaccinationApp.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() :
            base("PVApplication")
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Vaccination> Vaccinations { get; set; }
    }
}