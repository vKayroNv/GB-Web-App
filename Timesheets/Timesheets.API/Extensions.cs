using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Timesheets.Core.Services;
using Timesheets.Core.Services.Data;
using Timesheets.Domain.Managers;
using Timesheets.Interfaces.Managers;
using Timesheets.Interfaces.Repositories;
using Timesheets.Interfaces.Services;
using Timesheets.Storage.EF;
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
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();

            services.AddTransient<IUserService, UserService>();
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
                    new Core.MapperProfiles.LoginProfile(),
                    new Core.MapperProfiles.RefreshTokenProfile()
                   }));

            services.AddSingleton(cfg.CreateMapper());
        }

        public static void ConfigureDomain(this IServiceCollection services)
        {
            services.AddTransient<ISheetRepository, SheetRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();

            services.AddTransient<ISheetManager, SheetManager>();
            services.AddTransient<IInvoiceManager, InvoiceManager>();
        }
    }
}
