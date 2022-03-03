using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Timesheets.Core.Interfaces;
using Timesheets.Core.Services;
using Timesheets.Core.Services.Data;
using Timesheets.Domain.Managers;
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
                    new Core.MapperProfiles.RefreshTokenProfile(),

                    new MapperProfiles.EmployeeProfile(),
                    new MapperProfiles.UserProfile(),
                    new MapperProfiles.EntityProfile()
                   }));

            services.AddSingleton(cfg.CreateMapper());
        }

        public static void ConfigureDomain(this IServiceCollection services)
        {
            services.AddTransient<Domain.Interfaces.ISheetRepository, SheetRepository>();
            services.AddTransient<Domain.Interfaces.IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<Domain.Interfaces.ISheetManager, SheetManager>();
            services.AddTransient<Domain.Interfaces.IInvoiceManager, InvoiceManager>();
        }
    }
}
