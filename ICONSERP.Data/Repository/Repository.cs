using ICONSERP.Data.Context;
using ICONSERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ICONSERP.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private DbSet<T> _dbSet;
        public EntitiesContext _context;
        //public long UserID { get; set; } = HttpConfigs.UserID;
        public string LanguageID { get; set; }

        protected string[] defaultExcludedEditProperties = new string[]
             { "CreatedDate",
                 "CreatedBy",
                 "ID"
             };
     

        public Repository(EntitiesContext context)
        {
            _context = context;
           _dbSet = context.Set<T>();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
         string includeProperties = "")
        {
            IQueryable<T> query = _dbSet.Where(x => !x.IsDeleted);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!String.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).AsQueryable();
            }
            else
            {
                return query.AsQueryable();
            }
        }
        public virtual T Add(T entity)
        {
            //entity.CreatedBy = UserID;
            entity.CreatedDate = DateTime.Now;
            return _dbSet.Add(entity).Entity;
        }
        public virtual IEnumerable<T> AddRange(IEnumerable<T> entityList)
        {
            foreach (T entity in entityList)
                Add(entity);
            return entityList;
        }
        public virtual IEnumerable<T> EditRange(IEnumerable<T> entityList)
        {
            foreach (T entity in entityList)
                Edit(entity);
            return entityList;
        }
        public virtual T Edit(T entity)
        {
            if (defaultExcludedEditProperties.Any())
            {

                var oldEntity = _context.Set<T>().Local.FirstOrDefault(e => e.ID == entity.ID);
                if (oldEntity != null)
                    _context.Entry<T>(oldEntity).State = EntityState.Detached;

                _dbSet.Attach(entity);
                foreach (var name in defaultExcludedEditProperties)
                {
                    _context.Entry(entity).Property(name).IsModified = false;
                }
                var takenProp = _context.Entry<T>(entity).CurrentValues.Properties.Select(x => x.Name).Except(defaultExcludedEditProperties);
                foreach (var name in takenProp)
                {
                    _context.Entry(entity).Property(name).IsModified = true;
                }
                //entity.UpdatedBy = UserID;
                entity.UpdatedDate = DateTime.Now;
            }
            else
            {
                //entity.UpdatedBy = UserID;
                entity.UpdatedDate = DateTime.Now;
                _context.Entry<T>(entity).State = EntityState.Modified;
            }
            return entity;
        }
        public virtual void Remove(Guid id)
        {
            T entity = _dbSet.Where(x => !x.IsDeleted).FirstOrDefault(i => i.ID == id);
            //entity.DeletedBy = UserID;
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
        public virtual void Delete(Guid id)
        {
            T entity = _dbSet.FirstOrDefault(i => i.ID == id);
            _dbSet.Remove(entity);
        }
        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);

        }
        public virtual void RemoveRange(IEnumerable<Guid> Ids)
        {
            foreach (Guid id in Ids)
                Remove(id);
        }
        public virtual T GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(entity =>  entity.ID == id);
        }
        public async Task<T> GetByIdAsync(params object[] id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual T SaveExcluded(T entity, params string[] excludedProperties)
        {
            if (excludedProperties.Any())
            {

                var oldEntity = _context.Set<T>().Local.FirstOrDefault(e => e.ID == entity.ID);
                if (oldEntity != null)
                    _context.Entry<T>(oldEntity).State = EntityState.Detached;

                _dbSet.Attach(entity);
                // context.Configuration.ValidateOnSaveEnabled = false;
                //can i remove that
              //  context.ChangeTracker.AutoDetectChangesEnabled = false;
              
                foreach (var name in excludedProperties)
                {
                    _context.Entry(entity).Property(name).IsModified = false;
                }
                var takenProp = _context.Entry<T>(entity).CurrentValues.Properties.Select(x=>x.Name).Except(excludedProperties).Except(new[] { "ID"});
                foreach (var name in takenProp)
                {

                    _context.Entry(entity).Property(name).IsModified = true;
                }
                //entity.UpdatedBy = UserID;
                entity.UpdatedDate = DateTime.Now;
            }
            //else
            //{
            //    context.Entry<Entity>(entity).State = EntityState.Modified;
            //}
            return entity;
        }
        public virtual T SaveIncluded(T entity, params string[] included)
        {
            if (included.Any())
            {
                var oldEntity = _context.Set<T>().Local.FirstOrDefault(e => e.ID == entity.ID);
                if (oldEntity != null)
                    _context.Entry<T>(oldEntity).State = EntityState.Detached;

                _dbSet.Attach(entity);
              //  context.Configuration.ValidateOnSaveEnabled = false;
                foreach (var name in included)
                {
                    _context.Entry(entity).Property(name).IsModified = true;
                }
                var excludedProps = _context.Entry<T>(entity).CurrentValues.Properties.Select(x=>x.Name).Except(included);
                foreach (var name in excludedProps)
                {
                    _context.Entry(entity).Property(name).IsModified = false;
                }
                //entity.UpdatedBy = UserID;
                entity.UpdatedDate = DateTime.Now;
            }
            //else
            //{
            //    context.Entry<Entity>(entity).State = EntityState.Modified;
            //}
           return entity;
        }
        public virtual IQueryable<T> GetAll()
        {
           var query =  _dbSet.Where(x=>!x.IsDeleted);

            //var navigations = _context.Model.FindEntityType(typeof(T))
            //.GetDerivedTypesInclusive()
            //.SelectMany(type => type.GetNavigations())
            //.Distinct();

            //foreach (var property in navigations)
            //    query = query.Include(property.Name);

            return query;
        }
        public async Task<IQueryable<T>> GetAllAsync()
        {
            var items = await _dbSet.Where(x => !x.IsDeleted).ToListAsync();
            return items.AsQueryable();
        }
        public virtual int GeCount()
        {
            return _dbSet.Where(x => !x.IsDeleted).Count();
        }
        public virtual IQueryable<T> Find(Expression<Func<T, bool>> @where)
        {
            return _dbSet.Where(x => !x.IsDeleted).Where(@where);
        }
        public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> where)
        {
            var items = await _dbSet.Where(x => !x.IsDeleted).Where(@where).ToListAsync();
            return items.AsQueryable();
        }
        public virtual T Single(Expression<Func<T, bool>> @where)
        {
            return _dbSet.Where(x => !x.IsDeleted).Single(where) ?? _dbSet.Where(x => !x.IsDeleted)?.SingleOrDefault(@where); ;
        }
        public virtual T First(Expression<Func<T, bool>> @where)
        {
            var query =  _dbSet.Where(x => !x.IsDeleted).Where(@where);

            //var navigations = _context.Model.FindEntityType(typeof(T))
            //.GetDerivedTypesInclusive()
            //.SelectMany(type => type.GetNavigations())
            //.Distinct();

            //foreach (var property in navigations)
            //    query = query.Include(property.Name);

            return query.FirstOrDefault();
        }
        public virtual IQueryable<T> Skip(Expression<Func<T, bool>> order, int skipRows, int? takenRows)
        {
            return takenRows == null ? _dbSet.Where(x => !x.IsDeleted).OrderBy(order).Skip(skipRows) :
             _dbSet.Where(x => !x.IsDeleted).OrderBy(order).Skip(skipRows).Take(takenRows.Value);
        }
    }
}
