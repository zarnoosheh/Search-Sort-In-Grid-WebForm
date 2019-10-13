using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GridSample.Repository.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(
                 ref int listCount,
                 Expression<Func<TEntity, bool>> filter = null,
                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                 int page = 0,
                 int pageSize = 0);
    }
}