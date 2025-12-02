using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StoreOnline.API.Controllers
{
    public abstract class APIControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public APIControllerBase(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
