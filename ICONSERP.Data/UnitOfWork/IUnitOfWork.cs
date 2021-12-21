namespace ICONSERP.Data
{
    public interface IUnitOfWork
    {
       // Dictionary<Type, object> Repositories { get; set; }
        T Repository<T>() where T : class;
       // IRepository<T> TestRepository<T>() where T : class;
        int Commit();
        void Rollback();
    }
}
