using System.Threading.Tasks;
using Blazorise;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazorise.Components;
namespace Acme.BookStore.Blazor.Client;

public class Program
{
    public async static Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services
    .AddBlazorise()
    .AddBlazoriseRouterTabs();
        var application = await builder.AddApplicationAsync<BookStoreBlazorClientModule>(options =>
        {
            options.UseAutofac();
        });

        var host = builder.Build();

        await application.InitializeApplicationAsync(host.Services);

        await host.RunAsync();
    }
}
