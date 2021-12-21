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
            //public DbSet<User> Users { get; set; }
            //public DbSet<Role> Roles { get; set; }               
        }
    }
}
