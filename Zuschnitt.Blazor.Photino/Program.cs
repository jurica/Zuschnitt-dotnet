using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;
using Photino.Blazor;
using Zuschnitt.Razor;
using Zuschnitt.Models;

namespace Zuschnitt.Blazor.Photino
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var builder = PhotinoBlazorAppBuilder.CreateDefault(args);

            builder.Services
                .AddLogging();

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddFluentUIComponents();
            builder.Services.AddSingleton<AppState>();

            var app = builder.Build();

            app.MainWindow
                //.SetIconFile(favicon.ico)
                .SetTitle("Zuschnitt");

            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
                app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
            };

            app.Run();
        }
    }
}
