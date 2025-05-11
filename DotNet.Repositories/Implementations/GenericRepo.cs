using DotNet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Repositories.Implementations
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        public void DeleteRange(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disabledTraking = true)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disabledTraking = true)
        {
            throw new NotImplementedException();
        }

        public Task RemoveData(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
