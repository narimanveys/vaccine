using System.Collections.Generic;
using PattientVaccinationApp.Core.Model;

namespace PattientVaccinationApp.Service
{
    public interface IService<T> where T : EntityBase
    {
        #region Methods

        T Get(int id);

        List<T> GetAll();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        #endregion
    }
}