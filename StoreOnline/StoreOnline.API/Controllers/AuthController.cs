using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreOnline.API.Controllers.Base;
using StoreOnline.API.DTOs.Users;
using StoreOnline.Domain.UseCases.UserUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.UserUseCases.Commands.Login;

namespace StoreOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : APIControllerBase
    {
        public AuthController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost("registration")]
        public async Task<ActionResult> Create([FromBody] CreateUserDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateUserCommand>(dto);

            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<LoginUserCommand>(dto);
            var token = await _mediator.Send(command, cancellationToken);
            return Ok(token);
        }
    }
}
