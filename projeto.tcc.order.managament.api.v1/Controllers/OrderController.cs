using MediatR;
using Microsoft.AspNetCore.Mvc;
using projeto.tcc.order.managament.application.Commands;
using projeto.tcc.order.managament.domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto.tcc.order.managament.data.Queries.AssetsQueries;

namespace projeto.tcc.order.managament.api.v1.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IOrderQuery _orderQuery;

        public OrderController(IMediator mediator, INotificationHandler<ExceptionNotification> notifications, IOrderQuery orderQuery) : base(notifications)
        {
            _mediator = mediator;
            _orderQuery = orderQuery;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserOrder([FromBody] CreateOrderCommand createOrderCommand)
        {                
            var result = await _mediator.Send(createOrderCommand);

            return Response(200, result);
        }

        [HttpGet]
        public async Task<IActionResult> ListActiveOrdersByUser([FromQuery] Guid userId)
        {
            var query = _orderQuery.GetActiveOrders(userId);

            return Response(200, query);
        }
    }
}
