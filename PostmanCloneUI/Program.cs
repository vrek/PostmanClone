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

            var services = new ServiceCollection();
            ConfigureServices(services);

            _serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            var logDB = _serviceProvider.GetRequiredService<ILogDB>();
            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));
            var mainForm = _serviceProvider.GetRequiredService<frmMain>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<ILog>(provider => LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType));
            services.AddDbContext<LogDbContext>(options =>
               options.UseSqlite("Data Source=Logs.db"));
            services.AddScoped<ILogDB, LogDB>();
            services.AddTransient<frmMain>();
            //services.AddLibraryService();
        }
    }
}