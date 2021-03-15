using MailSender.Data;
using MailSender.Infrastructure.Services;
using MailSender.Infrastructure.Services.InDatabase;
using MailSender.lib;
using MailSender.lib.Interfaces;
using MailSender.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace MailSender
{
    public partial class App
    {
        private static IHost _Hosting;
        public static IHost Hosting => _Hosting
            ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
            public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(opt => opt.AddJsonFile("appsettings.json", false, true))
            .ConfigureServices(ConfigureServices)
            ;
        public static IServiceProvider Services => Hosting.Services;

        protected override void OnStartup(StartupEventArgs e)
        {
            using (var scope = Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
                initializer.InitializeAsync().Wait();
            }
                base.OnStartup(e);
        }

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection servises)
        {
            servises.AddDbContext<MailSenderDb>(opt => opt.UseSqlServer(host.Configuration.GetConnectionString("SqlServer")));
            servises.AddTransient<DbInitializer>();

            servises.AddSingleton<MainWindowViewModel>();
            servises.AddSingleton<StatisticViewModel>();

            //servises.AddSingleton<IRepository<Server>, ServersRepository>();
            //servises.AddSingleton<IRepository<Sender>, SendersRepository>();
            //servises.AddSingleton<IRepository<Recipient>, RecipientsRepository>();
            //servises.AddSingleton<IRepository<Message>, MessagesRepository>();

            servises.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));

            servises.AddSingleton<IStatistic, InMemoryStatisticService>();

#if DEBUG
            servises.AddSingleton<IMailService, DebugMailService>();
#else
            servises.AddSingleton<IMailService, SmtpMailService>();
#endif
        }
    }
}
