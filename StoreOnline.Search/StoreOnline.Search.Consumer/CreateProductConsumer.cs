using Confluent.Kafka;
using StoreOnline.Contracts;
using StoreOnline.Search.Api.grpc;
using System.Diagnostics;

namespace StoreOnline.Search.API
{
    public class CreateProductConsumer : BackgroundService
    {
        private readonly IConsumer<Null, string> _consumer;
        private readonly ILogger<CreateProductConsumer> _logger;
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _factory;
        private readonly SearchEngine.SearchEngineClient _searchEngineClient;
        private static readonly ActivitySource _activitySource = new ActivitySource("StoreOnline.Search.API.CreateProductConsumer");
        public CreateProductConsumer(IConsumer<Null, string> consumer, ILogger<CreateProductConsumer> logger, IConfiguration configuration, IServiceScopeFactory factory, SearchEngine.SearchEngineClient searchEngineClient)
        {
            _consumer = consumer;
            _logger = logger;
            _configuration = configuration;
            _factory = factory;
            _searchEngineClient = searchEngineClient;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe(_configuration.GetValue<string>("kafka:topic"));

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = _consumer.Consume(stoppingToken);        
                    
                    _logger.LogInformation($"Received message at {consumeResult.TopicPartitionOffset}, {consumeResult.Message.Value}");

                    var command = System.Text.Json.JsonSerializer.Deserialize<CreateProductMessage>(consumeResult.Message.Value!);

                    await _searchEngineClient.IndexAsync(new IndexRequest
                    {
                        Id = command.Id.ToString(),
                        Name = command.Name,
                        Description = command.Description
                    }, cancellationToken : stoppingToken);

                    using var activity = _activitySource
                        .StartActivity("Consume CreateProductMessage", ActivityKind.Consumer, ActivityContext
                        .TryParse(command.ActivityId, null, out var context) ? context : default);

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
