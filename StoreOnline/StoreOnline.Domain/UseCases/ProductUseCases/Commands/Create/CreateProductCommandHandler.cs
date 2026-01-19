using Confluent.Kafka;
using Domain.UseCases.ProductUseCases.Abstract;
using Domain.UseCases.ProductUseCases.Models;
using MediatR;

namespace StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductModel>
{
    private readonly IProductStorage _storage;
    private readonly Confluent.Kafka.IProducer<Null, string> _producer;

    public CreateProductCommandHandler(IProductStorage storage, IProducer<Null, string> producer)
    {
        _storage = storage;
        _producer = producer;
    }
    public async Task<ProductModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        var productModel = await _storage.Create(request, cancellationToken);

        CreateProductMessage productMessage = new CreateProductMessage
        {
            Id = productModel.Id,
            Name = request.Name!,
            Description = request.Description
        };

        var jSon = System.Text.Json.JsonSerializer.Serialize(productMessage);

        var message = new Message<Null, string>
        {
            Value = jSon
        };

        await _producer.ProduceAsync("create-product-topic", message);

        return productModel;

    }
}