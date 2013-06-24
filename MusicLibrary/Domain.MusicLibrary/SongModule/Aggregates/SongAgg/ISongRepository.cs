using MusicManager.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Domain.MusicLibrary.SongModule.Aggregates.SongAgg
{
    public interface ISongRepository:IRepository<Song>
    {
        IEnumerable<Song> GetGenere(string genere);

    }
}
