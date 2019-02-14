using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PattientVaccinationApp.Core.Model;

namespace PattientVaccinationApp.Data.Repository
{
    public class PatientsRepository : IRepository<Patient>
    {
        #region Fields

        private readonly ApplicationContext _appContext;

        #endregion

        #region Constructor

        public PatientsRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        #endregion

        #region Methods

        public Patient Get(int id)
        {
            return _appContext.Patients.Find(id);
        }

        public List<Patient> GetAll()
        {
            return _appContext.Patients.ToList();
        }

        public void Insert(Patient entity)
        {
            _appContext.Patients.Add(entity);
        }

        public void Update(Patient entity)
        {
            _appContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Patient entity)
        {
            _appContext.Patients.Remove(entity);
        }

        public void SaveChanges()
        {
            _appContext.SaveChanges();
        }

        #endregion
    }
}