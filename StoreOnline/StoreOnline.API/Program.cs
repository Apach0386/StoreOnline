using Domain.Dependency.Injection;
using Microsoft.EntityFrameworkCore;
using Storage;
using Storage.Dependency.Injection;
using StoreOnline.API.MiddleWares;
using StoreOnline.API.Monitoring;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDomain(builder.Configuration);
builder.Services.AddAutoMapper(config => config.AddMaps(typeof(Program).Assembly));
builder.Services.AddStorage(builder.Configuration);
builder.Services.AddOpenTelemetryMonitoring(builder.Configuration);


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ErrorMiddleWare>();
app.MapControllers();
app.MapPrometheusScrapingEndpoint();
using (var scope = app.Services.CreateScope()) 
{
    await scope.ServiceProvider.GetRequiredService<StoreDbContext>().Database.MigrateAsync();
}
    app.Run();
