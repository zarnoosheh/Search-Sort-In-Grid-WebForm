using GridSample.Repository.Base;
using GridSimple.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Linq.Expressions;

namespace GridSimple.Repository.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal SimpleGridDBEntities context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(SimpleGridDBEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public GenericRepository()
        {
        }

        public virtual IEnumerable<TEntity> Get(
             ref int listCount,
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             int page = 0,
             int pageSize = 0)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (listCount != -1)
                listCount = query.Count();

            if (orderBy != null)
                query = orderBy(query);

            if (page != 0 && pageSize != 0)
                return query.Skip((page - 1) * pageSize).Take(pageSize);

            return query;
        }
    }
}