using projeto.tcc.order.managament.domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.data.Queries.AssetsQueries
{
    public interface IOrderQuery : IQueries<Order>
    {
        Task<IEnumerable<dynamic>> GetActiveOrders(Guid userId);
    }
}
