using API.TrainerHub.DTOs.Book;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainerHub.API.DTOs.Book;
using TrainerHub.Domain.UseCases.BookUseCases.Commands.Create;

namespace API.TrainerHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class _001_BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public _001_BookController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] CreateBookDto dto, CancellationToken cancellationToken)
        {

            var command = _mapper.Map<CreateBookCommand>(dto);
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook([FromBody] UpdateBookDto dto, CancellationToken cancellationToken)
        { 
            
        }
    }
}
