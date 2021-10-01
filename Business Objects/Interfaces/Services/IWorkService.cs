using System.Collections.Generic;
namespace Business_Objects.Interfaces.Services
{
    interface IWorkService<T> where T : class
    {
        
        ///
        /// Get all items of Work table
        /// 
        /// 
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
    }
   
}
