using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OneStreamSample.Client.Services;
using OneStreamSample.Client.Services.Interfaces;

namespace OneStreamSample.Client;

internal class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddScoped<IOneStreamService, OneStreamService>();

        await builder.Build().RunAsync();
    }
}
