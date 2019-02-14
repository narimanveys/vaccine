using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PattientVaccinationApp.Core.Model;
using PattientVaccinationApp.Data;
using PattientVaccinationApp.Data.Repository;
using PattientVaccinationApp.Service.Patient;
using PattientVaccinationApp.Service.Vaccination;

namespace PattientVaccinationApp
{
    public static class IocConfiguration
    {
        #region Methods

        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ApplicationContext>().As<ApplicationContext>();
            builder.RegisterType(typeof(PatientsRepository)).As(typeof(IRepository<Patient>)).InstancePerDependency();
            builder.RegisterType(typeof(VaccinationsRepository)).As(typeof(IRepository<Vaccination>)).InstancePerDependency();
            builder.RegisterType(typeof(VaccinationService)).As(typeof(IVaccinationService));
            builder.RegisterType(typeof(PatientService)).As(typeof(IPatientService));

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        #endregion
    }
}