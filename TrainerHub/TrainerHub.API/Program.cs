using Domain.Dependency.Injection;
using Microsoft.EntityFrameworkCore;
using Storage.Dependency.Injection;
using Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDomain();
builder.Services.AddAutoMapper(config => config.AddMaps(typeof(Program).Assembly));
builder.Services.AddStorage(builder.Configuration);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetRequiredService<TrainerDBContext>().Database.MigrateAsync();
}
app.Run();
