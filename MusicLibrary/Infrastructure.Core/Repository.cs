using MusicManager.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Infrastructure.Core
{
    public class Repository<TEntity>:IRepository<TEntity>
        where TEntity:Entity
    {

        #region Members

        IQueryableUnitOfWork _UnitOfWork;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == (IQueryableUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork");

            _UnitOfWork = unitOfWork;
        }

        #endregion

        public IUnitOfWork UnitOfWork
        {
            get { return _UnitOfWork; }
        }

        public void Add(TEntity item)
        {
            if (item != (TEntity)null)
                GetSet().Add(item); 
        }

        public void Remove(TEntity item)
        {
            if (item != (TEntity)null)
            {
                
                _UnitOfWork.Attach(item);

                
                GetSet().Remove(item);
            }
        }

        public TEntity Get(Guid id)
        {
            if (id != Guid.Empty)
                return GetSet().Find(id);
            else
                return null;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return GetSet();
        }
        public void Merge(TEntity persisted, TEntity current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        public void Dispose()
        {
            if (_UnitOfWork != null)
                _UnitOfWork.Dispose();
        }

        #region Private Methods

        IDbSet<TEntity> GetSet()
        {
            return _UnitOfWork.CreateSet<TEntity>();
        }
        #endregion
    }
}
