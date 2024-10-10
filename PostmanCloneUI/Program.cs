using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PostManCloneLibrary;
using PostManCloneLibrary.Context;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace PostmanCloneUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));
        private static IServiceProvider _serviceProvider;
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ServiceCollection services = new();
            ConfigureServices(services);

            _serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            log4net.Repository.ILoggerRepository logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetExecutingAssembly());
            _ = XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));
            frmMain mainForm = _serviceProvider.GetRequiredService<frmMain>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            _ = services.AddSingleton(provider =>
            {
                return LogManager.GetLogger(type: MethodBase.GetCurrentMethod().DeclaringType);
            });
            _ = services.AddDbContext<LogDbContext>(options =>
               options.UseSqlite("Data Source=Logs.db"));
            _ = services.AddScoped<ILogDB, LogDB>();
            _ = services.AddTransient<frmMain>();
            //services.AddLibraryService();
        }
    }
}