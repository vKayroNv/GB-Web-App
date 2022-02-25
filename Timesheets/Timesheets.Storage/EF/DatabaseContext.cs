using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Timesheets.Storage.EF.Configuration;
using Timesheets.Storage.Models;

namespace Timesheets.Storage.EF
{
    public class DatabaseContext : DbContext
    {
        //dotnet ef migrations add InitialCreate --configuration MIGRATE
        //dotnet ef database update

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        private readonly IConfiguration _configuration;

#if DEBUG || RELEASE
        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
#endif

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // ???
        {
#if MIGRATE
            if (optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                return;
            }

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(@"D:\randomthings\C#\GB-Web-App\Timesheets\Timesheets.API")
                .AddJsonFile("appsettings.json");

            _configuration = configurationBuilder.Build();
#endif
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("database"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
