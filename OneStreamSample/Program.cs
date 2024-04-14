using OneStreamSample.Client.Services.Interfaces;
using OneStreamSample.Client.Services;
using OneStreamSample.Components;
using OneStreamSample.ConfigOptions;
using OneStreamSample.Services.Interfaces;
using OneStreamSample.Services;

namespace OneStreamSample;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<WebApiOptions>(builder.Configuration.GetSection(WebApiOptions.WebAPI));

        builder.Services.AddHttpClient();

        builder.Services.AddScoped<IOneStreamService, OneStreamService>();
        builder.Services.AddScoped<IFrontEndService, FrontEndService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

        app.MapControllers();

        app.Run();
    }
}
