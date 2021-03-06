using Microsoft.EntityFrameworkCore;
using Survey.Core.Interfaces.Infastructure;
using Survey.Data.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Data.Infastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        private readonly SurveyDbContext _context;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(SurveyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IList<TEntity>> GetAllAsync(string[] children =null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (children != null)
            {
                foreach (string entity in children)
                {
                    query = query.Include(entity);

                }
            }
            return await query.AsNoTracking().ToListAsync();

        }

        public async Task<IList<TEntity>> GetWhere(Expression<Func<TEntity, bool>> filter = null, string[] children = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (children != null)
            {
                foreach (string entity in children)
                {
                    query = query.Include(entity);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                await _dbSet.AddAsync(entity);
            }

            return entity;
        }
        public async Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);

            return entities;
        }

       
    }
}
