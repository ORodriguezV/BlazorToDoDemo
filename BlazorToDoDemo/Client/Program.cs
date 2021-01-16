using BlazorToDoDemo.Client.Helpers;
using BlazorToDoDemo.Client.Repositories;
using BlazorToDoDemo.Shared.IRepositories;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorToDoDemo.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
            builder.Services.AddScoped<IStatusRepository, StatusRepository>();

            await builder.Build().RunAsync();
        }
    }
}
