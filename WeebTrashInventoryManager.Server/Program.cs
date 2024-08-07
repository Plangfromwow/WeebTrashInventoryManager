using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

 IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseElectron(args);
            webBuilder.UseStartup<StartupBase>();
        });


 async void ElectronBootstrap()
{
    BrowserWindowOptions options = new BrowserWindowOptions
    {
        Show = false,
    };
    BrowserWindow mainWindow = await Electron.WindowManager.CreateWindowAsync(options);
    mainWindow.OnReadyToShow += () =>
    {
        mainWindow.Show();
        mainWindow.SetTitle("Weebtrash Inventory Manager");

    };

}

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await Electron.WindowManager.CreateWindowAsync();

    ElectronBootstrap();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
