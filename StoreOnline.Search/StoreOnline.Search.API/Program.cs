using Confluent.Kafka;
using StoreOnline.Search.API;
using StoreOnline.Search.Domain.DependencyInjection;
using StoreOnline.Search.Storage.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDomain();
builder.Services.AddAutoMapper(config => config.AddMaps(typeof(Program).Assembly));
builder.Services.AddStoreOnlineSearchStorage(builder.Configuration.GetConnectionString("SearchEngine")!);
builder.Services.AddSingleton<IConsumer<Null, string>>(sp => new ConsumerBuilder<Null, string>(new ConsumerConfig
{
    BootstrapServers = builder.Configuration.GetValue<string>("kafka:bootstrapServers"),
    GroupId = builder.Configuration.GetValue<string>("kafka:groupId"),
    AutoOffsetReset = builder.Configuration.GetValue<AutoOffsetReset>("kafka:autoOffsetReset"),
    EnableAutoCommit = builder.Configuration.GetValue<bool>("kafka:enableAutoCommit")    
}).Build());

builder.Services.AddHostedService<CreateProductConsumer>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();


app.Run();
