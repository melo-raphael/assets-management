using AutoMapper;
using MediatR;
using projeto.tcc.order.managament.application.Commands;
using projeto.tcc.order.managament.domain.Aggregates.OrderAggregate;
using projeto.tcc.order.managament.domain.Exceptions;
using projeto.tcc.order.managament.domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.application.CommandsHandlers
{
    public class CreateOrderCommandHandler : CommandHandler, IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public CreateOrderCommandHandler(IOrderRepository orderRepository, INotificationHandler<ExceptionNotification> notifications,
                                         IMapper mapper, IMediator bus,
                                         IUnitOfWork uow = null) : base(notifications, bus, uow)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
            }


            var orderFound = await _orderRepository.GetActiveOrders(request.AssetId);

            if (orderFound != null)
            {
                orderFound.UpdateActiveOrder(request.Amount, request.Type);

                if (orderFound.IsCloseOrder())
                {
                    _orderRepository.DeleteActiveOrder(orderFound);
                }

                orderFound.AddCreatingOrderDomainEvent();
            }

            else
            {
                var order = _mapper.Map<Order>(request);
                order.CreateNewActiveOrder();

                _orderRepository.Add(order);
            }

            if (await Commit())
            {
                return true;
            }

            return false;
        }
    }
}
