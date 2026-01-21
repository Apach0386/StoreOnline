using Confluent.Kafka;

namespace StoreOnline.Search.API
{
    public class CreateProductConsumer : BackgroundService
    {
        private readonly IConsumer<Null, string> _consumer;
        private readonly ILogger<CreateProductConsumer> _logger;
        private readonly IConfiguration _configuration;

        public CreateProductConsumer(IConsumer<Null, string> consumer, ILogger<CreateProductConsumer> logger, IConfiguration configuration)
        {
            _consumer = consumer;
            _logger = logger;
            _configuration = configuration;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe(_configuration.GetValue<string>("kafka:topic"));

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = _consumer.Consume(stoppingToken);
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
