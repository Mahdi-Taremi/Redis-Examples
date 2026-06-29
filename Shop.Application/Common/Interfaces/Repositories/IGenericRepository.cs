using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity>
     where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task AddAsync(
            TEntity entity,
            CancellationToken cancellationToken = default);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
