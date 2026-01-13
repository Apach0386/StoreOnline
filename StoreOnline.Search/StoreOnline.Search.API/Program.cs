using StoreOnline.Search.Domain.DependencyInjection;
using StoreOnline.Search.Storage.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDomain();
builder.Services.AddAutoMapper(config => config.AddMaps(typeof(Program).Assembly));
builder.Services.AddStoreOnlineSearchStorage(builder.Configuration.GetConnectionString("SearchEngine")!);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();


app.Run();
