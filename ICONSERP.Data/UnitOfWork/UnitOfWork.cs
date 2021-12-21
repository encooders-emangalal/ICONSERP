using ICONSERP.Data.Context;
using ICONSERP.Data.Repository;
using ICONSERP.Models.Models.Identity;

namespace ICONSERP.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntitiesContext _context;
        private readonly IServiceProvider _serviceProvider;
        private readonly HttpContext _httpContext;

       // private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        //public Dictionary<Type, object> Repositories
        //{
        //    get { return _repositories; }
        //    set { Repositories = value; }
        //}
        public UnitOfWork(EntitiesContext context, IHttpContextAccessor accessor, IServiceProvider serviceProvider)
        {
            _httpContext = accessor.HttpContext;
            _context = context;
            _serviceProvider = serviceProvider;
        }
        public UnitOfWork()
        {
            _context = new EntitiesContext();
        }
        public T Repository<T>() where T : class

        {
            var interfaceType = typeof(T).GetInterface($"I{typeof(T).Name}");
            
             T repo =(T) _serviceProvider.GetRequiredService(interfaceType);
         
             return repo;
        }
        //public IRepository<T> TestRepository<T>() where T : class
        //{
        //if (Repositories.Keys.Contains(typeof(T)))
        //{
        //    return Repositories[typeof(T)] as T;
        //}

        //    var interfaceType = typeof(T).GetInterface($"I{typeof(T).Name}");

        //    // T repo =(T) _serviceProvider.GetRequiredService(interfaceType);
        //    var respositoryType = typeof(IRepository<T>);
        //   var repo = (Repository<T> ) _serviceProvider.GetRequiredService(respositoryType);

        //    // T repo = (T)Activator.CreateInstance(typeof(T), new object[] { _context });

        //    Repositories.Add(typeof(T), repo);
        //    return repo;
        //}
        public int Commit()
        {
            return _context.SaveChanges();
        }
        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        private Repository<Role> roleRepository;
        public Repository<Role> RoleRepository
        {
            get => CreateRepository(ref roleRepository);
        }

        private Repository<User> userRepository;
        public Repository<User> UserRepositoryOwner
        {
            get => CreateRepository(ref userRepository);
        }
        private Repository<UserRole> userRoleRepository;
        public Repository<UserRole> UserRoleRepository
        { 
        get => CreateRepository(ref userRoleRepository);
        }
        private Repository<RoleModuleResourcePermission> roleModuleResourcePermissionRepository;
        public Repository<RoleModuleResourcePermission> RoleModuleResourcePermissionRepository
        {
            get => CreateRepository(ref roleModuleResourcePermissionRepository);
        }





        private T CreateRepository<T>(ref T field) where T : class// Repository<BaseModel>
        {
            if (field == null)
            {
                var constructor = typeof(T).GetConstructor(new[] { typeof(EntitiesContext), typeof(int) });
                if (constructor != null)
                {
                    field = (T)constructor.Invoke(new object[] { _context });
                }
            }
            return field;
        }
    }
}
