using MediatR;

namespace StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Delete;

public class DeleteCategoryCommand : IRequest
{
    public Guid Id { get; set; }
}
