using System;
using System.Collections.Generic;
using System.Text;

namespace projeto.tcc.order.managament.proxy.wallet.src
{
    public class WalletRequest
    {
        private string symbol;
        private decimal value;

        public Guid UserId { get; set; }
        public AssetRequestDto Asset { get; set; }

        public int Amount { get; set; }
        public bool IsCloseOrder { get; set; }
        public string OrderType { get; set; }

        public WalletRequest(Guid userId, AssetRequestDto assetRequestDto, int amount, bool isCloseOrder, string orderType)
        {
            UserId = userId;
            this.Asset = assetRequestDto;
            Amount = amount;
            IsCloseOrder = isCloseOrder;
            OrderType = orderType;
        }
    }

    public class AssetRequestDto
    {
        public AssetRequestDto(string symbol, decimal startPrice)
        {
            Symbol = symbol;
            StartPrice = startPrice;
        }

        public string Symbol { get; set; }
        public decimal StartPrice { get; set; }

    }
}
