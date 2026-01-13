using Domain.UseCases.ProductUseCases.Abstract;
using Domain.UseCases.ProductUseCases.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.CreateFromFile;

public class CreateFromFileProductCommandHandler : IRequestHandler<CreateFromFileProductCommand>
{
    private readonly IProductStorage _storage;
    private readonly ILogger<CreateFromFileProductCommandHandler> _logger;

    public CreateFromFileProductCommandHandler(IProductStorage storage, ILogger<CreateFromFileProductCommandHandler> logger)
    {
        _storage = storage;
        _logger = logger;
    }
    public async Task Handle(CreateFromFileProductCommand command, CancellationToken cancellationToken)
    {

        const int bufferCount = 5;

        var buffer = new List<CreateProductCommand>(bufferCount);
        #region Найпростіший спосіб парсингу
        // Найпростіший спосіб парсингу

        //using var reader = new StreamReader(command.File);

        //var content = await reader.ReadToEndAsync(cancellationToken);

        //var products = JsonConvert.DeserializeObject<List<CreateProductCommand>>(content);

        //foreach (var product in products!)
        //{
        //    //await _storage.Create(product, cancellationToken);
        //}

        //_logger.LogInformation(content);

        #endregion 

        if (command.FileName.EndsWith(".json"))
        {

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            await foreach (var product in JsonSerializer.DeserializeAsyncEnumerable<CreateProductCommand>(command.File, options, cancellationToken))
            {
                buffer.Add(product!);

                if (buffer.Count == bufferCount)
                {

                    await _storage.Create(buffer, cancellationToken);

                    _logger.LogInformation("Created {Count} products", buffer.Count);

                    buffer.Clear();
                }
            }
            if (buffer.Count > 0)
            {
                await _storage.Create(buffer, cancellationToken);
                buffer.Clear();
            }
        }

        if (command.FileName.EndsWith(".csv"))
        {
            using var reader = new StreamReader(command.File);

            await reader.ReadLineAsync(cancellationToken);


            while (!reader.EndOfStream)
            { 
                var line = await reader.ReadLineAsync(cancellationToken);

                CreateProductCommand model = new CreateProductCommand();

                model.Name = line.Split(',')[0];
                model.Description = line.Split(',')[1];
                model.Price = decimal.Parse(line.Split(',')[2]);

                buffer.Add(model);

                if (buffer.Count == bufferCount)
                {
                    await _storage.Create(buffer, cancellationToken);
                    buffer.Clear();
                }
            }    
                if (buffer.Count > 0)
                {
                    await _storage.Create(buffer, cancellationToken);
                    buffer.Clear();
                }
        }

    }
}
