using Microsoft.Extensions.DependencyInjection;
using Timesheets.Storage.EF;
using Timesheets.Storage.Interfaces;
using Timesheets.Storage.Models;
using Timesheets.Storage.Repositories;

namespace Timesheets.API
{
    public partial class Startup
    {
        private void ConfigureStorageServices(IServiceCollection services)
        {
            services.AddSingleton<DatabaseContext>();

            services.AddSingleton<UserRepository>();
            services.AddSingleton<EmployeeRepository>();
        }
    }
}
