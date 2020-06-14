using System;
using System.Collections.Generic;
using System.Text;

namespace projeto.tcc.order.managament.domain.Events
{
    public class CreatingNewOrderDomainEvent : Event
    {

        public Guid UserId { get; set; }
        public Guid AssetId { get; set; }
        public bool IsClodeOrder { get; set; }
        public int Ammount { get; set; }
        public decimal Value { get; set; }
        public string OrderType { get; set; }

        public CreatingNewOrderDomainEvent(Guid userId, Guid assetId, bool isClodeOrder, int ammount, decimal value, string orderType)
        {
            UserId = userId;
            AssetId = assetId;
            IsClodeOrder = isClodeOrder;
            Ammount = ammount;
            Value = value;
            OrderType = orderType;
        }


    }
}
