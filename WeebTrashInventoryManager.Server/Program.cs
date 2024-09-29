using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using WeebTrashInventoryManager;

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
           webBuilder.UseStartup<StartupBase>();
       });

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

var context = new InventoryContext();
context.Database.EnsureCreated();

app.Run();
