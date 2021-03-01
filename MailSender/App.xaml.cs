using MailSender.Infrastructure;
using MailSender.Infrastructure.Services;
using MailSender.lib.Interfaces;
using MailSender.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection servises)
        {
            servises.AddSingleton<MainWindowViewModel>();
            servises.AddSingleton<StatisticViewModel>();
            servises.AddSingleton<ServersRepository>();
            servises.AddSingleton<IStatistic,InMemoryStatisticService>();
        }
    }
}
