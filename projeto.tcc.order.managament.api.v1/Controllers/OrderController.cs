using MediatR;
using Microsoft.AspNetCore.Mvc;
using projeto.tcc.order.managament.application.Commands;
using projeto.tcc.order.managament.domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.api.v1.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator, INotificationHandler<ExceptionNotification> notifications) : base(notifications)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserOrder([FromBody] CreateOrderCommand createOrderCommand)
        {
            var createOrder = createOrderCommand;
            createOrder.UserId = new Guid();        
    
            var result = await _mediator.Send(createOrder);

            return Response(200, result);
        }
    }
}
