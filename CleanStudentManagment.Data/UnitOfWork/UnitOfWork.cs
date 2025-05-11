using CleanStudentManagment.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            IGenericRepository<T> genericRepository=new GenericRepository<T>(_context);
            return genericRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #region IDisposable Members
        private bool _disposed = false;
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
    }
}
