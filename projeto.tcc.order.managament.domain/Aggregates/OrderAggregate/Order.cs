using projeto.tcc.order.managament.domain.Events;
using projeto.tcc.order.managament.domain.SeedWork;
using System;

namespace projeto.tcc.order.managament.domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        private Guid _userId;
        public Guid AssetId { get; private set; }

        private decimal _value;
        private int _amount;
        public OrderType OrderType { get; private set; }
        private int _orderTypeId;
        public OrderActive OrderActive { get; private set; }

        protected Order() { }
        public Order(Guid userId, decimal value, int amount, string orderType, Guid assetId)
        {
            _userId = userId;
            _value = value;
            _amount = amount;
            _orderTypeId = OrderType.FromName(orderType).Id;
            AssetId = assetId;

            this.AddCreatingOrderDomainEvent();
        }

        public void CreateNewActiveOrder()
        {
            OrderActive = new OrderActive(DateTime.Now, this._amount);
        }

        public void UpdateActiveOrder(int amount, string orderType)
        {
            var orderTypeId = OrderType.FromName(orderType).Id;

            if (orderTypeId != this._orderTypeId)
            {
                OrderActive.UpdateReverseActiveOrder(amount);
            }

            else
            {
                OrderActive.UpdateActiveOrder(amount);
            }
        }

        public bool IsCloseOrder()
        {
            if (OrderActive == null)
            {
                return false;
            }

            return OrderActive.IsCloseOrder();
        }

        public void AddCreatingOrderDomainEvent()
        {
            this.AddDomainEvent(new CreatingNewOrderDomainEvent(_userId, AssetId, IsCloseOrder(), this._amount, this._value, OrderType.From(_orderTypeId).Name));
        }
    }
}
