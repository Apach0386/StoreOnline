using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using StoreOnline.Search.Api.grpc;
using StoreOnline.Search.Domain.UseCases.Commands.Index;

namespace StoreOnline.Search.API.Controllers
{
    public class SearchEngineGrpcService  : SearchEngine.SearchEngineBase
    {
        private readonly IMediator _mediator;

        public SearchEngineGrpcService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task<Empty> Index(IndexRequest request, ServerCallContext context)
        {
            await _mediator.Send(new IndexCommand {
               Id = Guid.Parse( request.Id),
               Name = request.Name,
               Description = request.Description
            });

            return new Empty();
        }
    }
}
