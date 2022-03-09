using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Survey.Core.Interfaces.Infastructure
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync(string[] children = null);
        Task<IList<TEntity>> GetWhere(Expression<Func<TEntity, bool>> filter = null, string[] children = null);
        Task<TEntity> Add(TEntity entity);
        Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entities);
    }
}
