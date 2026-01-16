using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreOnline.Search.API.DTOs;
using StoreOnline.Search.Domain.UseCases.Commands.Index;
using StoreOnline.Search.Domain.UseCases.Queries.MultiMatchSearch;

namespace StoreOnline.Search.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ISearchStorage _storage;

        public SearchController(IMapper mapper, IMediator mediator, ISearchStorage storage)
        {
            _mapper = mapper;
            _mediator = mediator;
            _storage = storage;
        }

        [HttpPost("index")]
        public async Task<ActionResult> Index([FromBody] IndexDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<IndexCommand>(dto);
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpGet("search")]
        public async Task<ActionResult> Search([FromQuery] string query, CancellationToken cancellationToken)
        {
            var command = new MultiMatchSearchQuery { Query = query };
            var res = await _mediator.Send(command, cancellationToken);
            return Ok(res);
        }


    }
}
