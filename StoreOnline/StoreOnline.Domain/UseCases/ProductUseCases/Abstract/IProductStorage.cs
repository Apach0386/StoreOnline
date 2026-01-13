using Domain.UseCases.ProductUseCases.Models;
using StoreOnline.Domain.Base;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Delete;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Update;
using StoreOnline.Domain.UseCases.ProductUseCases.Queries.GetAll;
using StoreOnline.Domain.UseCases.ProductUseCases.Queries.GetById;

namespace Domain.UseCases.ProductUseCases.Abstract;

public interface IProductStorage : IStorage
{
    Task<ProductModel> Create(CreateProductCommand command, CancellationToken cancellationToken);    
    Task<ProductModel> GetById(GetProductQuery query, CancellationToken cancellationToken);
    Task<List<ProductModel>> GetAll(GetAllProductsQuery query, CancellationToken cancellationToken);
    Task<ProductModel> Update(UpdateProductCommand command, CancellationToken cancellationToken);
    Task Delete(DeleteProductCommand command, CancellationToken cancellationToken);
    Task Create(IEnumerable<CreateProductCommand> commands, CancellationToken cancellationToken);
}
