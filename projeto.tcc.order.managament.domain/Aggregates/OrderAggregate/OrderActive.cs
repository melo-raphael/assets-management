using projeto.tcc.order.managament.domain.SeedWork;
using System;

namespace projeto.tcc.order.managament.domain.Aggregates.OrderAggregate
{
    public class OrderActive : Entity
    {
        private DateTime _updateAt;
        private int _activeAmount;

        public OrderActive(DateTime orderTime, int activeAmount)
        {
            _updateAt = orderTime;
            _activeAmount = activeAmount;
        }

        protected OrderActive() { }

        public void UpdateReverseActiveOrder(int activeAmount)
        {
            _updateAt = DateTime.Now;
            _activeAmount -= activeAmount;
        }

        public void UpdateActiveOrder(int activeAmount)
        {
            _updateAt = DateTime.Now;
            _activeAmount += activeAmount;

        }

        public bool IsCloseOrder()
        {
            return _activeAmount == 0;
        }
    }
}
