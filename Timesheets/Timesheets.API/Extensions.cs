using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Timesheets.Core.Interfaces;
using Timesheets.Core.Services.Data;
using Timesheets.Storage.EF;
using Timesheets.Storage.Interfaces;
using Timesheets.Storage.Repositories;

namespace Timesheets.API
{
    public static class Extensions
    {
        public static void ConfigureStorageServices(this IServiceCollection services)
        {
            services.AddScoped<DatabaseContext>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }

        public static void ConfigureCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IDataUserService, DataUserService>();
            services.AddTransient<IDataEmployeeService, DataEmployeeService>();
        }

        public static void ConfigureMappers(this IServiceCollection services)
        {
            var cfg = new MapperConfiguration(mp => mp.AddProfiles(
                   new List<Profile>()
                   {
                    new Core.MapperProfiles.EmployeeProfile(),
                    new Core.MapperProfiles.UserProfile(),
                    new Core.MapperProfiles.EntityProfile(),

                    new MapperProfiles.EmployeeProfile(),
                    new MapperProfiles.UserProfile(),
                    new MapperProfiles.EntityProfile()
                   }));

            services.AddSingleton(cfg.CreateMapper());
        }
    }
}
