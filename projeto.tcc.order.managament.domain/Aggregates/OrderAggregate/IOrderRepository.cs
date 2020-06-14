using projeto.tcc.order.managament.domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task SendOrderToWalletAsync(Guid userId, string symbol, decimal value, int amount, bool isCloseOrder, string orderType);
        Task<Order> GetActiveOrders(Guid assetId);
        void DeleteActiveOrder(Order order);
    }
}
