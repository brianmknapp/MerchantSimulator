using MerchantSimulatorApi.Core.Interfaces;
using MerchantSimulatorApi.Domain.Entities;
using MerchantSimulatorApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MerchantSimulatorApi.Infrastructure.Repository
{
    public class EfRepository<T, TId> : IRepository<T, TId> where T : BaseEntity<TId>
    {
        private readonly AppDbContext Context;
        private DbSet<T> Entities { get; set; }

        public EfRepository(AppDbContext context)
        {
            Context = context;
            Entities = Context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException($"{nameof(entity)}");
            }
            await Entities.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
