using ICONSERP.Data.Context;
using ICONSERP.Data.Repository;
using ICONSERP.Models.Identity;
using ICONSERP.Models.Models;
using ICONSERP.Models.Models.Identity;
using ICONSERP.Models.Models.Shared;

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
        public UnitOfWork(EntitiesContext dbContext)
        {
            if (dbContext != null)
                _context = dbContext;
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

        private Repository<LogType> logTypeRepository;
        public Repository<LogType> LogTypeRepository
        {
            get => CreateRepository(ref logTypeRepository);
        }

        private Repository<Module> moduleRepository;
        public Repository<Module> ModuleRepository
        {
            get => CreateRepository(ref moduleRepository);
        }
        private Repository<ModuleResource> moduleResourceRepository;
        public Repository<ModuleResource> ModuleResourceRepository
        {
            get => CreateRepository(ref moduleResourceRepository);
        }
        private Repository<Permission> permissionRepository;
        public Repository<Permission> PermissionRepository
        {
            get => CreateRepository(ref permissionRepository);
        }

        private Repository<Resource> resourceRepository;
        public Repository<Resource> ResourceRepository
        {
            get => CreateRepository(ref resourceRepository);
        }
        private Repository<ResourceType> resourceTypeRepository;
        public Repository<ResourceType> ResourceTypeRepository
        {
            get => CreateRepository(ref resourceTypeRepository);
        }


        private Repository<Models.Models.Identity.Role> roleRepository;
        public Repository<Models.Models.Identity.Role> RoleRepository
        {
            get => CreateRepository(ref roleRepository);
        }


        private Repository<RoleModuleResourcePermission> roleModuleResourcePermissionRepository;
        public Repository<RoleModuleResourcePermission> RoleModuleResourcePermissionRepository
        {
            get => CreateRepository(ref roleModuleResourcePermissionRepository);
        }

        private Repository<Token> tokenRepository;
        public Repository<Token> TokenRepository
        {
            get => CreateRepository(ref tokenRepository);
        }

        private Repository<TokenLog> tokenLogRepository;
        public Repository<TokenLog> TokenLogRepository
        {
            get => CreateRepository(ref tokenLogRepository);
        }


        private Repository<TokenType> tokenTypeRepository;
        public Repository<TokenType> TokenTypeRepository
        {
            get => CreateRepository(ref tokenTypeRepository);
        }

        private Repository<User> userRepository;
        public Repository<User> UserRepository
        {
            get => CreateRepository(ref userRepository);
        }

        private Repository<UserRole> userRoleRepository;
        public Repository<UserRole> UserRoleRepository
        { 
        get => CreateRepository(ref userRoleRepository);
        }


        private Repository<ApplicationModule> applicationModuleRepository;
        public Repository<ApplicationModule> ApplicationModuleRepository
        {
            get => CreateRepository(ref applicationModuleRepository);
        }

        private Repository<Models.Models.BillingCycle> billingCycleRepository;
        public Repository<Models.Models.BillingCycle> BillingCycleRepository
        {
            get => CreateRepository(ref billingCycleRepository);

        }

        private Repository<Country> countryRepository;
        public Repository<Country> CountryRepository
        {
            get => CreateRepository(ref countryRepository);
        }
        private Repository<Currency> currencyRepository;
        public Repository<Currency> CurrencyRepository
        {
            get => CreateRepository(ref currencyRepository);
        }
        private Repository<Plan> planRepository;
        public Repository<Plan> PlanRepository
        {
            get => CreateRepository(ref planRepository);
        }

        private Repository<Unit> unitRepository;
        public Repository<Unit> UnitRepository
        {
            get => CreateRepository(ref unitRepository);
        }
        private Repository<UserStatus> userStatusRepository;
        public Repository<UserStatus> UserStatusRepository
        {
            get => CreateRepository(ref userStatusRepository);
        }

        private Repository<Proffession> proffessionRepository;
        public Repository<Proffession> ProffessionRepository
        {
            get => CreateRepository(ref proffessionRepository);
        }

        private Repository<Tenant> tenantRepository;
        public Repository<Tenant> TenantRepository
        {
            get => CreateRepository(ref tenantRepository);
        }

        private T CreateRepository<T>(ref T field) where T : class// Repository<BaseModel>
        {
            if (field == null)
            {
                var constructor = typeof(T).GetConstructor(new[] { typeof(EntitiesContext) });
                if (constructor != null)
                {
                    field = (T)constructor.Invoke(new object[] { _context });
                }
            }
            return field;
        }
    }
}
