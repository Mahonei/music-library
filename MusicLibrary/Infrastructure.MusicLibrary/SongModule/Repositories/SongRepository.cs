using MusicManager.Domain.MusicLibrary.SongModule.Aggregates.SongAgg;
using MusicManager.Infrastructure.Core;
using MusicManager.Infrastructure.MusicLibrary.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Infrastructure.MusicLibrary.SongModule.Repositories
{
    public class SongRepository:Repository<Song>,ISongRepository
    {
         #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public SongRepository(MainMLUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        public IEnumerable<Song> GetGenere(string genere)
        {
            var currentUnitOfWork = this.UnitOfWork as MainMLUnitOfWork;
            return currentUnitOfWork.Songs
                .Where(c => String.Compare(c.Genre, genere, true) == 0)
                .OrderBy(c => c.Title);
        }
        
    }
}
