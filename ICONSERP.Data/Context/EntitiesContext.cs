using ICONSERP.Models.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace ICONSERP.Data.Context
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
        }
        public EntitiesContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //public DbSet<User> Users { get; set; }
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleModuleResourcePermission> RoleModuleResourcePermissions { get; set; }
        
        
    }

}

