using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.UseCases.ProductUseCases.Models;
using Microsoft.EntityFrameworkCore;
using Storage;
using StoreOnline.Domain.UseCases.CategoryUseCases.Abstract;
using StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Delete;
using StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Update;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;
using StoreOnline.Domain.UseCases.CategoryUseCases.Queries.GetAll;
using StoreOnline.Domain.UseCases.CategoryUseCases.Queries.GetById;
using StoreOnline.Storage.Entities;

namespace StoreOnline.Storage.Storages;

public class CategoryStorage : ICategoryStorage
{
    private readonly StoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CategoryStorage(StoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<CategoryModel> Create(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Category>(command);

        await _dbContext.Categories.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var res = _dbContext.Categories
            .AsNoTracking()
            .FirstAsync(x => x.Id == entity.Id, cancellationToken);

        return _mapper.Map<CategoryModel>(res);

    }
    public async Task<CategoryModel> Update(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories
            .FirstAsync(x => x.Id == command.Id, cancellationToken);

        category.Name = command.Name;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CategoryModel>(category);
    }
    public async Task<CategoryModel> GetById(GetCategoryQuery query, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories
            .AsNoTracking()
            .FirstAsync(x => x.Id == query.Id);

        return _mapper.Map<CategoryModel>(category);
    }
    public async Task<List<CategoryModel>> GetAll(GetAllCategoryQueries queries, CancellationToken cancellationToken)
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .ProjectTo<CategoryModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }



    public Task<bool> IsExist(Guid entityId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
       Category category = await _dbContext.Categories.FirstAsync(c => c.Id == command.Id);

        _dbContext.Categories.Remove(category!);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
