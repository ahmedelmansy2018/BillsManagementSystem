
using Business_Objects.Interfaces;
using Business_Objects.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_layer.Service
{
    public class WorkService<T> : IWorkService<T> where T : class
    {
        private readonly IUnitOfWork<T> _unitOfWork;
        public WorkService(IUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Delete(object id)
        {
            _unitOfWork.Entity.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Entity.GetAll();
        }

        public T GetById(object id)
        {
            return _unitOfWork.Entity.GetById(id);
        }

        public void Insert(T entity)
        {
            _unitOfWork.Entity.Insert(entity);
            _unitOfWork.Save();
        }

        public void Update(T entity)
        {
            _unitOfWork.Entity.Update(entity);
            _unitOfWork.Save();
        }
    }
}
