
using System.Collections.Generic;
using PattientVaccinationApp.Data.Repository;

namespace PattientVaccinationApp.Service.Vaccination
{
    public class VaccinationService : IVaccinationService
    {
        #region Fields

        private readonly IRepository<Core.Model.Vaccination> _vaccinationRepository;

        #endregion

        #region Constructor

        public VaccinationService(IRepository<Core.Model.Vaccination> vaccinationRepository)
        {
            _vaccinationRepository = vaccinationRepository;
        }
        #endregion  

        #region Methods

        public Core.Model.Vaccination Get(int id)
        {
           return _vaccinationRepository.Get(id);
        }

        public List<Core.Model.Vaccination> GetAll()
        {
            return _vaccinationRepository.GetAll();
        }

        public void Insert(Core.Model.Vaccination entity)
        {
            _vaccinationRepository.Insert(entity);
            _vaccinationRepository.SaveChanges();
        }

        public void Update(Core.Model.Vaccination entity)
        {
            _vaccinationRepository.Update(entity);
            _vaccinationRepository.SaveChanges();
        }

        public void Delete(Core.Model.Vaccination entity)
        {
            _vaccinationRepository.Delete(entity);
            _vaccinationRepository.SaveChanges();
        }

        #endregion
    }
}