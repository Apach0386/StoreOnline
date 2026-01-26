using Confluent.Kafka;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IConsumer<Null, string>>(sp => new ConsumerBuilder<Null, string>(new ConsumerConfig
{
    BootstrapServers = builder.Configuration.GetValue<string>("kafka:bootstrapServers"),
    GroupId = builder.Configuration.GetValue<string>("kafka:groupId"),
    AutoOffsetReset = builder.Configuration.GetValue<AutoOffsetReset>("kafka:autoOffsetReset"),
    EnableAutoCommit = builder.Configuration.GetValue<bool>("kafka:enableAutoCommit")
}).Build());

var app = builder.Build();


app.Run();
