using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.ProductUseCases.Abstract;
using Domain.UseCases.ProductUseCases.Models;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Delete;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Update;
using StoreOnline.Domain.UseCases.ProductUseCases.Queries.GetAll;
using StoreOnline.Domain.UseCases.ProductUseCases.Queries.GetById;

namespace Storage.Sorages.Products;

public class ProductStorage : IProductStorage
{
    private readonly StoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public ProductStorage(StoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<ProductModel> Create(CreateProductCommand command, CancellationToken cancellationToken)
    {

        Product entity = _mapper.Map<Product>(command);

        await _dbContext.Products.AddAsync(entity, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        var res = await _dbContext.Products
            .AsNoTracking()
            .FirstAsync(x => x.Id == entity.Id, cancellationToken);

        return _mapper.Map<ProductModel>(res);

    }

    public async Task<ProductModel> GetById(GetProductQuery query, CancellationToken cancellationToken)
    {
        var product = _dbContext.Products
           .AsNoTracking()
           .FirstAsync(x => x.Id == query.Id);

        return _mapper.Map<ProductModel>(product);
    }



    public async Task<List<ProductModel>> GetAll(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .ProjectTo<ProductModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductModel> Update(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
            .AsNoTracking()
            .FirstAsync(x => x.Id == command.Id);

        product.Name = command.Name;
        product.Description = command.Description;
        product.Price = command.Price;

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<ProductModel>(product);
    }

    public async Task Delete(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        Product product = await _dbContext.Products.FirstAsync(x => x.Id == command.Id, cancellationToken);

        _dbContext.Products.Remove(product);

        await _dbContext.SaveChangesAsync(cancellationToken);

    }    

    public Task<bool> IsExist(Guid entityId, CancellationToken cancellationToken)
    {
        return _dbContext.Products
            .AnyAsync(x => x.Id == entityId);
    }

}
