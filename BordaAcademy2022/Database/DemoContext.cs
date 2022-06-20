using BordaAcademy2022.Entities;
using Microsoft.EntityFrameworkCore;

namespace BordaAcademy2022.Database
{
    public class DemoContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DemoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Student> Students => Set<Student>();

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = _configuration.GetConnectionString("Database");

            builder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityAlwaysColumns();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoContext).Assembly);
        }

    }
}
