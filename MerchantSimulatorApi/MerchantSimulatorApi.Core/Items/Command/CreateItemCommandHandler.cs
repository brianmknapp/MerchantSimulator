using MediatR;
using MerchantSimulatorApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MerchantSimulatorApi.Core.Item.Command
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, ShopItem>
    {
        public Task<ShopItem> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
