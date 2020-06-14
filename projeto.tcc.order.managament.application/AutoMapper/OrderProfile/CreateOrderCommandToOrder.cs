using AutoMapper;
using projeto.tcc.order.managament.application.Commands;
using projeto.tcc.order.managament.domain.Aggregates.OrderAggregate;

namespace projeto.tcc.order.managament.application.AutoMapper.OrderProfile
{
    public class CreateOrderCommandToOrder : Profile
    {
        public CreateOrderCommandToOrder()
        {
            CreateGetAllAssetsResponseDto();
        }

        private void CreateGetAllAssetsResponseDto()
        {
            CreateMap<CreateOrderCommand, Order>().ConstructUsing(c => new Order(c.UserId, c.Value, c.Amount, c.Type, c.AssetId));
        }
    }
}
