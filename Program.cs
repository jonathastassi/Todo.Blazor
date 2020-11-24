using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;
using todo.Services;

namespace todo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();    

            builder.Services
                .AddScoped<ITodoService, TodoService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            var settings = new RefitSettings();
            // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddRefitClient<IWebApi>(settings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:3000/"));

            var host = builder.Build();
            var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
            await authenticationService.Initialize();

            await host.RunAsync();
        }
    }
}
