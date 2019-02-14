using System.Collections.Generic;
using PattientVaccinationApp.Data.Repository;

namespace PattientVaccinationApp.Service.Patient
{
    public class PatientService : IPatientService
    {
        #region Fields

        private readonly IRepository<Core.Model.Patient> _patientRepository;

        #endregion

        #region Constructor

        public PatientService(IRepository<Core.Model.Patient> patinentRepository)
        {
            _patientRepository = patinentRepository;
        }

        #endregion

        #region Methods
        public Core.Model.Patient Get(int id)
        {
            return _patientRepository.Get(id);
        }

        public List<Core.Model.Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public void Insert(Core.Model.Patient entity)
        {
            _patientRepository.Insert(entity);
            _patientRepository.SaveChanges();
        }

        public void Update(Core.Model.Patient entity)
        {
            _patientRepository.Update(entity);
            _patientRepository.SaveChanges();
        }

        public void Delete(Core.Model.Patient entity)
        {
            _patientRepository.Delete(entity);
            _patientRepository.SaveChanges();
        }
        #endregion
    }
}