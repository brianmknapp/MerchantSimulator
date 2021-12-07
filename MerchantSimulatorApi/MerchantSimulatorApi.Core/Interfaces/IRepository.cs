using MerchantSimulatorApi.Domain.Entities;
using System.Threading.Tasks;

namespace MerchantSimulatorApi.Core.Interfaces
{
    public interface IRepository<T, TId> where T : BaseEntity<TId>
    {
        Task<T> CreateAsync(T entity);
    }
}
