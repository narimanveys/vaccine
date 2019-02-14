using System.Collections.Generic;
using System.Threading.Tasks;
using PattientVaccinationApp.Core.Model;

namespace PattientVaccinationApp.Data.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        #region Methods

        T Get(int id);

        List<T> GetAll();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SaveChanges();

        #endregion
    }
}