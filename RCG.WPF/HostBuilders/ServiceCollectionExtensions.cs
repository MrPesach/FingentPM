using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RCG.CoreApp.Interfaces.Auth;
using RCG.CoreApp.Interfaces.DbContexts;
using RCG.CoreApp.Interfaces.Repositories;
using RCG.CoreApp.Interfaces.Shared;
using RCG.CoreApp.Services.Auth;
using RCG.Data.DbContexts;
using RCG.Data.Repositories;
using RCG.WPF.State.Accounts;
using RCG.WPF.State.Authenticators;
using RCG.WPF.State.Navigators;
using Shared.Services;

namespace RCG.WPF.HostBuilders
{
    public static class ServiceCollectionExtensions
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("appsettings.json");
                c.AddEnvironmentVariables();
            });

            return host;
        }

        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);

                services.AddDbContext<ApplicationDbContext>(configureDbContext);
            });

            return host;
        }

        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<IUserStore, UserStore>();
            });

            return host;
        }

        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IDateTimeService, SystemDateTimeService>();
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
                services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
                services.AddSingleton(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
                services.AddSingleton<IUnitOfWork, UnitOfWork>();
                services.AddSingleton<IAuthService, AuthService>();
                services.AddSingleton<IUserRepository, UserRepository>();
            });

            return host;
        }
    }
}
