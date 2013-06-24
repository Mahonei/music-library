using MusicManager.Application.MusicLibrary.DTO.SongModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicaManager.Application.MusicLibrary.SongModule.Services
{
    public interface ISongService:IDisposable
    {
        /// <summary>
        /// Add new song
        /// </summary>
        /// <param name="songDTO">The song information</param>
        /// <returns>Added song representation</returns>
        SongDTO AddNewSong(SongDTO songDTO);

        /// <summary>
        /// Update existing song
        /// </summary>
        /// <param name="songDTO">The songdto with changes</param>
        void UpdateSong(SongDTO songDTO);

        /// <summary>
        /// Remove existing song
        /// </summary>
        /// <param name="customerId">The song identifier</param>
        void RemoveSong(Guid songId);


        /// <summary>
        /// Find song with contain specific genere
        /// </summary>
        /// <param name="genere">the genere to seach</param>
        /// <returns>A collection of song representation</returns>
        List<SongDTO> FindSongByGenere(string genre);

        /// <summary>
        /// Find all songs
        /// </summary>
        /// <returns>A collection of song representation</returns>
        List<SongDTO> FindSongs();

    }
}
