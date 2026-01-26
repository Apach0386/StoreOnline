using Confluent.Kafka;
using StoreOnline.Contracts;
using System.Diagnostics;

namespace StoreOnline.Search.API
{
    public class CreateProductConsumer : BackgroundService
    {
        private readonly IConsumer<Null, string> _consumer;
        private readonly ILogger<CreateProductConsumer> _logger;
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _factory;

        private static readonly ActivitySource _activitySource = new ActivitySource("StoreOnline.Search.API.CreateProductConsumer");
        public CreateProductConsumer(IConsumer<Null, string> consumer, ILogger<CreateProductConsumer> logger, IConfiguration configuration, IServiceScopeFactory factory)
        {
            _consumer = consumer;
            _logger = logger;
            _configuration = configuration;
            _factory = factory;

        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe(_configuration.GetValue<string>("kafka:topic"));

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = _consumer.Consume(stoppingToken);

                    using var scope = _factory.CreateScope();
                    

                    var command = System.Text.Json.JsonSerializer.Deserialize<CreateProductMessage>(consumeResult.Message.Value!);

                    using var activity = _activitySource.StartActivity("Consume CreateProductMessage", ActivityKind.Consumer, ActivityContext.TryParse(command.ActivityId, null, out var context) ? context : default);

                    
                    _logger.LogInformation($"Consumed message '{consumeResult.Message.Value}' at: '{consumeResult.TopicPartitionOffset}'.");
                    _consumer.Commit(consumeResult);
                }
                catch (ConsumeException ex)
                {
                    _logger.LogError($"Error occurred: {ex.Error.Reason}");
                }
            }

            await Task.Yield();
        }
    }
}
