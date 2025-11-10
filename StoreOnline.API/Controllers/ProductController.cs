using API.StoreOnline.DTOs.Products;
using AutoMapper;
using Domain.UseCases.ProductUseCases.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Delete;
using StoreOnline.Domain.UseCases.ProductUseCases.Commands.Update;
using StoreOnline.Domain.UseCases.ProductUseCases.Queries.GetAll;
using StoreOnline.Domain.UseCases.ProductUseCases.Queries.GetById;

namespace API.StoreOnline.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductDto request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateProductCommand>(request);
            var model = await _mediator.Send(command, cancellationToken);
            var dto = _mapper.Map<ProductDto>(model);
            return Ok(dto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromQuery] Guid id, [FromBody] UpdateProductDto productDto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateProductCommand>(productDto);
            command.Id = id;

            var model = await _mediator.Send(command, cancellationToken);
            var dto = _mapper.Map<ProductDto>(model);

            return Ok(dto);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery { Id = id };

            ProductModel model = await _mediator.Send(query, cancellationToken);

            return Ok(_mapper.Map<ProductDto>(model));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            List<ProductModel> models = await _mediator.Send(query, cancellationToken);

            var productDtos = _mapper.Map<List<ProductDto>>(models);

            return Ok(productDtos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        { 
            DeleteProductCommand command = new DeleteProductCommand { Id = id};
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
