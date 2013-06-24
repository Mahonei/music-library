using MusicaManager.Application.MusicLibrary.Resources;
using MusicManager.Application.MusicLibrary.DTO.SongModule;
using MusicManager.Domain.MusicLibrary.SongModule.Aggregates.SongAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicManager.Infrastructure.Crosscutting.Validator;
using MusicManager.Application.Seedwork;

namespace MusicaManager.Application.MusicLibrary.SongModule.Services
{
    public class SongService:ISongService
    {
        #region Members
        
        private readonly ISongRepository _songRepository;
        
        #endregion

        #region Constructors
        
        public SongService(ISongRepository songRepository) {
            if (songRepository == null)
                throw new ArgumentNullException("songRepository");

            _songRepository = songRepository;
        }

        #endregion


        #region ISongService Members

        public SongDTO AddNewSong(SongDTO songDTO)
        {
            if (songDTO == null )
                throw new ArgumentException(Messages.warning_CannotAddSongWithEmptyInformation);

            var song = new Song(songDTO.Title, songDTO.Author, songDTO.Album, songDTO.Genre);
            SaveSong(song);


            return song.ProjectedAs<SongDTO>(); 
        }

        public void UpdateSong(SongDTO songDTO)
        {
            if (songDTO == null || songDTO.Id == Guid.Empty)
                throw new ArgumentException(Messages.warning_CannotUpdateSongWithEmptyInformation);//throw new ArgumentException(Messages.warning_CannotUpdateSongWithEmptyInformation);

            var persisted = _songRepository.Get(songDTO.Id);

            if (persisted != null) 
            {
                var current = new Song();
                current.ChangeCurrentIdentity(songDTO.Id);
                current.Title = songDTO.Title;
                current.Author = songDTO.Author;
                current.Album = songDTO.Album;
                current.Genre = songDTO.Genre;

                _songRepository.Merge(persisted, current);

                _songRepository.UnitOfWork.Commit();
            }
        }

        public void RemoveSong(Guid songId)
        {
            var song = _songRepository.Get(songId);
            if (song != null) {
                _songRepository.Remove(song);
                _songRepository.UnitOfWork.Commit();
            }
        }

        public List<SongDTO> FindSongByGenere(string genre)
        {
            var songs = _songRepository.GetGenere(genre);
            if (songs != null && songs.Any()) {
                return songs.ProjectedAsCollection<SongDTO>();
            }
            return null;
        }
        public List<SongDTO> FindSongs()
        {
            var songs = _songRepository.GetAll();
            if (songs != null && songs.Any())
            {
                return songs.ProjectedAsCollection<SongDTO>();
            }
            return null;
        }

        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _songRepository.Dispose();
        }

        #endregion


        #region Private Methods

        void SaveSong(Song song)
        {
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(song)) //if customer is valid
            {
                _songRepository.Add(song);
                _songRepository.UnitOfWork.Commit();
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages<Song>(song));
        }

        Song MaterializeSongFromDto(SongDTO songDTO)
        {

            Song song = new Song(songDTO.Title, songDTO.Author, songDTO.Album, songDTO.Genre);
            return song;
        }

       
        #endregion


        
    }
}
