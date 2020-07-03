using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Domain.Entities;

namespace AspNetCore.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> InsertAsync (TEntity entity);
        Task<TEntity> UpdateAsync (TEntity entity);
        Task<bool> DeleteAsync (Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<TEntity> SelectAsync (Guid id);
        Task<IEnumerable<TEntity>> SelectAsync ();
    }
}