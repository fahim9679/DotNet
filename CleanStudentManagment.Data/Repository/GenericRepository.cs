using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Data.Repository
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            if(_context.Entry(entity).State==EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public async Task<T> DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            return entity;
        }

        public void DeleteById(int id)
        {
            T entityToDelete=_dbSet.Find(id);
            Delete(entityToDelete);
        }

        public async Task DeleteByIdAsync(int id)
        {
            T entityToDelete = await _dbSet.FindAsync(id);
            Delete(entityToDelete);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #region IDisposable Members
        private bool _disposed=false;
        protected virtual void Dispose(bool dispossing)
        {
            if (!this._disposed)
            {
                if (dispossing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        #endregion
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filler = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;
            if(filler != null)
            {
                query = query.Where(filler);
            }
            
            foreach(var includeProperty in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
            {
                query= query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
