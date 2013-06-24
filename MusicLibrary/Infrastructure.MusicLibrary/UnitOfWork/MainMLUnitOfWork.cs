using MusicManager.Domain.Core;
using MusicManager.Domain.MusicLibrary.SongModule.Aggregates.SongAgg;
using MusicManager.Infrastructure.Core;
using MusicManager.Infrastructure.MusicLibrary.UnitOfWork.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Infrastructure.MusicLibrary.UnitOfWork
{
    public class MainMLUnitOfWork:DbContext, IQueryableUnitOfWork
    {
        #region IDbSet Members

        IDbSet<Song> _songs;
        public IDbSet<Song> Songs
        {
            get
            {
                if (_songs == null)
                    _songs = base.Set<Song>();

                return _songs;
            }
        }

        

        #endregion

        #region IQueryableUnitOfWork Members

        public void Commit()
        {
            base.SaveChanges();
        }

        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
           
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        public void Attach<TEntity>(TEntity item)
           where TEntity : class
        {
            //attach and set as unchanged
            base.Entry<TEntity>(item).State = System.Data.EntityState.Unchanged;
        }

        #endregion

        #region DbContext Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {          
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
 
            modelBuilder.Configurations.Add(new SongEntityConfiguration());
        }
        #endregion




        
    }
}
