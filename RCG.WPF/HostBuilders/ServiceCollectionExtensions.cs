using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RCG.CoreApp.AppResources;
using RCG.CoreApp.Interfaces.DbContexts;
using RCG.CoreApp.Interfaces.Product;
using RCG.CoreApp.Interfaces.Repositories;
using RCG.CoreApp.Interfaces.Settings;
using RCG.CoreApp.Interfaces.Shared;
using RCG.CoreApp.Interfaces.User;
using RCG.CoreApp.Services.Product;
using RCG.CoreApp.Services.Settings;
using RCG.CoreApp.Services.User;
using RCG.Data.DbContexts;
using RCG.Data.Repositories;
using RCG.WPF.Services;
using RCG.WPF.State.Accounts;
using RCG.WPF.State.Authenticators;
using RCG.WPF.State.Navigators;
using Shared.Services;

namespace RCG.WPF.HostBuilders
{
    public static class ServiceCollectionExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            var dbfilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Resource.PathDatabase;
            if (!Directory.Exists(dbfilePath))
            {
                Directory.CreateDirectory(dbfilePath);
            }

            host.ConfigureServices((context, services) =>
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite("Data Source=" + @dbfilePath + "data.fin");
                });
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
                services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
                services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
                services.AddTransient<IUnitOfWork, UnitOfWork>();
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<IUserRepository, UserRepository>();
                services.AddTransient<IProductRepository, ProductRepository>();
                services.AddTransient<IProductService, ProductService>();
                services.AddTransient<IDialogService, DialogService>();
                services.AddTransient<IApplConfigsRepository, ApplConfigsRepository>();
                services.AddTransient<ISettingsService, SettingsService>();
            });

            return host;
        }
    }
}
