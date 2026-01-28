using Domain.UseCases.ProductUseCases.Models;
using StoreOnline.Domain.Base;
using StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Delete;
using StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Update;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;
using StoreOnline.Domain.UseCases.CategoryUseCases.Queries.GetAll;
using StoreOnline.Domain.UseCases.CategoryUseCases.Queries.GetById;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;

namespace StoreOnline.Domain.UseCases.CategoryUseCases.Abstract;

public interface ICategoryStorage : IStorage
{
    Task<CategoryModel> Create(CreateCategoryCommand command, CancellationToken cancellationToken);
    Task<CategoryModel> Update(UpdateCategoryCommand command, CancellationToken cancellationToken);
    Task<CategoryModel> GetById(GetCategoryQuery query, CancellationToken cancellationToken);
    Task<List<CategoryModel>> GetAll(GetAllCategoryQueries queries, CancellationToken cancellationToken);
    Task Delete (DeleteCategoryCommand command, CancellationToken cancellationToken);    
}
