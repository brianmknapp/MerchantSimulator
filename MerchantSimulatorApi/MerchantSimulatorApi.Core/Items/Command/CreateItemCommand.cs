using MerchantSimulatorApi.Domain.Entities;
using MediatR;


namespace MerchantSimulatorApi.Core.Item.Command
{
    public class CreateItemCommand : IRequest<ShopItem>
    {
        public ShopItem ShopItem { get; set; }
    }
}
