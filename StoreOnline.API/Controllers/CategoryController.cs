using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreOnline.API.Controllers.Base;
using StoreOnline.API.DTOs.Categories;
using StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Delete;
using StoreOnline.Domain.UseCases.CategoryUseCases.Commands.Update;
using StoreOnline.Domain.UseCases.CategoryUseCases.Models;
using StoreOnline.Domain.UseCases.CategoryUseCases.Queries.GetAll;
using StoreOnline.Domain.UseCases.CategoryUseCases.Queries.GetById;

namespace StoreOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : APIControllerBase
    {
        public CategoryController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
               

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateCategoryCommand>(dto);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(dto);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetById([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetCategoryQuery { Id = id };
            CategoryModel model = await _mediator.Send(query, cancellationToken);

            return Ok(_mapper.Map<CategoryDto>(model));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] GetAllCategoryQueries query, CancellationToken cancellationToken)
        {
            List<CategoryModel> models = await _mediator.Send(query, cancellationToken);

            var categorytDtos = models.Select(_mapper.Map<CategoryDto>);

            return Ok(categorytDtos);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteCategoryCommand { Id = id };

            await _mediator.Send(command, cancellationToken);            

            return NoContent();
        }
    }
}
