using Microsoft.Extensions.Configuration;
using WebScraperApp.Controllers;

namespace WebScraperApp;

static class Program
{
    public static IConfiguration Configuration;
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        Configuration = builder.Build();

        MainController controller = new MainController();

        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow(controller));
    }
}