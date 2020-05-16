using MediatR;
using Microsoft.AspNetCore.Mvc;
using projeto.tcc.order.managament.application.Queries;
using projeto.tcc.order.managament.domain.Exceptions;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.api.v1.Controllers
{
    public class AssetsController : BaseController
    {
        private readonly IMediator _mediator;

        public AssetsController(IMediator mediator, INotificationHandler<ExceptionNotification> notifications) : base(notifications)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssetsForPage([FromQuery] string pageNumber)
        {
            var query = new GetAssetsQuery(pageNumber);

            var result = await _mediator.Send(query);

            return Response(200, result);
        }

    }
}
