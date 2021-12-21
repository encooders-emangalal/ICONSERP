using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ICONSERP.Data.Repository
{
    public interface IRepository<T>
    {
        //Guid UserID { get; set; }
        string LanguageID { get; set; }
        IQueryable<T> GetAll();
        void RemoveRange(IEnumerable<Guid> ids);
        Task<IQueryable<T>> GetAllAsync();
        T GetById(Guid id);
        Task<T> GetByIdAsync(params object[] id);
        T Add(T entity);
        IEnumerable<T> EditRange(IEnumerable<T> entityList);
        IEnumerable<T> AddRange(IEnumerable<T> entityList);
        T Edit(T entity);
        void Remove(Guid id);
        int GeCount();
        IQueryable<T> Find(Expression<Func<T, bool>> where);
        Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> where);
        T Single(Expression<Func<T, bool>> where);
        T First(Expression<Func<T, bool>> where);
        T SaveIncluded(T entity, params string[] includedProperties);
        T SaveExcluded(T entity, params string[] excludedProperties);
         void DeleteRange(IEnumerable<T> entities);
        void Delete(Guid id);
    }
}
