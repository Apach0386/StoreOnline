using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using StoreOnline.Search.API.DTOs;
using StoreOnline.Search.Domain.UseCases.Commands.Index;

namespace StoreOnline.Search.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SearchController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
           _mediator = mediator;
        }

        [HttpPost("index")]
        public async Task<ActionResult> Index([FromBody] IndexDto dto, CancellationToken cancellationToken )
        { 
            var command = _mapper.Map<IndexCommand>(dto);
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
        
    }
}
