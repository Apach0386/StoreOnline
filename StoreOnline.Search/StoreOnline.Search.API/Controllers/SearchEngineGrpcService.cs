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
        private readonly ILogger<SearchEngineGrpcService> _logger;

        public SearchEngineGrpcService(IMediator mediator, ILogger<SearchEngineGrpcService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        public override async Task<Empty> Index(IndexRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Received Index request for Id: {Id}, Name: {Name}", request.Id, request.Name);
            await _mediator.Send(new IndexCommand {
               Id = Guid.Parse( request.Id),
               Name = request.Name,
               Description = request.Description
            });

            return new Empty();
        }
    }
}
