using Microsoft.Extensions.DependencyInjection;
using Timesheets.Storage.EF;
using Timesheets.Storage.Interfaces;
using Timesheets.Storage.Repositories;

namespace Timesheets.API
{
    public partial class Startup
    {
        private void ConfigureStorageServices(IServiceCollection services)
        {
            services.AddScoped<DatabaseContext>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
