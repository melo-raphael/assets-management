using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projeto.tcc.order.managament.data.Context;
using projeto.tcc.order.managament.domain.Aggregates.OrderAggregate;
using projeto.tcc.order.managament.proxy.wallet.src;

namespace projeto.tcc.order.managament.data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }

        public void DeleteActiveOrder(Order order)
        {
            _appDbContext.Entry(order.OrderActive).State = EntityState.Deleted;
        }

        public async Task<Order> GetActiveOrders(Guid assetId)
        {
           return await _dbSet.Include(x => x.OrderActive).FirstOrDefaultAsync(y => y.AssetId == assetId);
        }

        public async Task SendOrderToWalletAsync(Guid userId, string symbol, decimal value, int amount, bool isCloseOrder, string orderType)
        {
            using (var client = new WalletClient())
            {
                var assetsRequestDto = new AssetRequestDto(symbol, value);
                var walletRequest = new WalletRequest(userId, assetsRequestDto, amount, isCloseOrder, orderType);
                await client.SendOrderAsync(walletRequest);
            }
        }
    }
}
