using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Reflection.PortableExecutable;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.ConfigureWebHostDefaults(webHostBuilder =>
//{
//    webHostBuilder.UseUrls("http://*1000");
//});


builder.WebHost.ConfigureKestrel(options => options.ListenAnyIP(1000));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
