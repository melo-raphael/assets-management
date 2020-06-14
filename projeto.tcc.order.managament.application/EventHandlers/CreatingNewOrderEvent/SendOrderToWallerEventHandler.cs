using projeto.tcc.order.managament.domain.Aggregates.AssetsAggregate;
using projeto.tcc.order.managament.domain.Aggregates.OrderAggregate;
using projeto.tcc.order.managament.domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.application.EventHandlers.CreatingNewOrderEvent
{
    public class SendOrderToWallerEventHandler : EventHandler<CreatingNewOrderDomainEvent>
    {
        private readonly IAssetsRepository _assetRepository;
        private readonly IOrderRepository _orderRepository;
        public SendOrderToWallerEventHandler(IAssetsRepository assetRepository, IOrderRepository orderRepository)
        {
            _assetRepository = assetRepository;
            _orderRepository = orderRepository;
        }

        public async override Task Handle(CreatingNewOrderDomainEvent notification, CancellationToken cancellationToken)
        {
            var asset = await _assetRepository.GetAssetById(notification.AssetId);

            await _orderRepository.SendOrderToWalletAsync(notification.UserId, asset.Symbol, notification.Value, notification.Ammount, notification.IsClodeOrder, notification.OrderType);

            await Task.CompletedTask;
        }
    }
}
