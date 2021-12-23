using ICONSERP.Models.Identity;
using ICONSERP.Models.Models;
using ICONSERP.Models.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace ICONSERP.Data.Context
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
        }       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
        }
        public DbSet<LogType> LogTypes { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleResource> ModuleResources { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<Models.Models.Identity.Role> Roles { get; set; }
        public DbSet<RoleModuleResourcePermission> RoleModuleResourcePermissions { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<TokenLog> TokenLogs { get; set; }
        public DbSet<TokenType> TokenTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    
       
        //lookups
        public DbSet<Models.Models.BillingCycle> BillingCycles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ApplicationModule> ApplicationModules { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }

        
    }

}

