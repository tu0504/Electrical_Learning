using ELECTRICAL_LEARNING.REPOSITORIES.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELECTRICAL_LEARNING.REPOSITORIES.Repository
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        Task Add(TEntity entity);
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetById(TKey id);
        Task Remove(TEntity entity);
        Task Update(TEntity entity);
        Task SaveChangesAsync();
    }
}
