
namespace Business_Objects.Interfaces
{
    interface IUnitOfWork<T> where T : class
    {
        IGenericRepository<T> Entity { get; }
        void Save();
    }
}

