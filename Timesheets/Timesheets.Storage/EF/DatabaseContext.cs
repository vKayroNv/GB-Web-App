using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Timesheets.Entities.Models;
using Timesheets.Storage.EF.Configuration;

namespace Timesheets.Storage.EF
{
    public sealed class DatabaseContext : DbContext
    {
        //dotnet ef migrations add InitialCreate --configuration MIGRATE
        //dotnet ef database update --configuration MIGRATE

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<RefreshToken> Tokens { get; set; }
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

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
                //.SetBasePath(@"D:\randomthings\C#\GB-Web-App\Timesheets\Timesheets.API")
                .SetBasePath(@"E:\Programs\GB-Web-App\Timesheets\Timesheets.API")
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
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new LoginConfiguration());
            modelBuilder.ApplyConfiguration(new SheetConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        }
    }
}
