using System;

namespace MerchantSimulatorApi.Domain.Entities
{
    public class ShopItem : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public Decimal Price { get; set; }
    }
}
