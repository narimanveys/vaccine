using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PattientVaccinationApp.Core.Model;

namespace PattientVaccinationApp.Data.Repository
{
    public class VaccinationsRepository : IRepository<Vaccination>
    {
        #region Fields

        private readonly ApplicationContext _appContext;

        #endregion

        #region Constructor

        public VaccinationsRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        #endregion

        #region Methods

        public Vaccination Get(int id)
        {
            return _appContext.Vaccinations
                .Include(x => x.Patient)
                .FirstOrDefault(entity => entity.Id == id);
        }

        public List<Vaccination> GetAll()
        {
            return _appContext.Vaccinations
                .Include(x => x.Patient)
                .ToList();
        }

        public void Insert(Vaccination entity)
        {
            _appContext.Vaccinations.Add(entity);
        }

        public void Update(Vaccination entity)
        {
            _appContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Vaccination entity)
        {
            _appContext.Vaccinations.Remove(entity);
        }

        public void SaveChanges()
        {
            _appContext.SaveChanges();
        }

        #endregion
    }
}