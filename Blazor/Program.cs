using Blazor;
using Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5050") });
builder.Services.AddScoped<IOrderProvider, OrdersProvider>();
builder.Services.AddScoped<IItemProvider, ItemsProvider>();
builder.Services.AddScoped<ICustomerProvider, CustomerProvider>();

await builder.Build().RunAsync();
