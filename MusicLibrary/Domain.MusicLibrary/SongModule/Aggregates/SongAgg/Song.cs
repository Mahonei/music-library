using MusicManager.Domain.Core;
using MusicManager.Domain.MusicLibrary.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Domain.MusicLibrary.SongModule.Aggregates.SongAgg
{
    public class Song : Entity, IValidatableObject
    {
        public Song(string title, string author, string album, string genre) {
            this.Title = title;
            this.Author = author;
            this.Album = album;
            this.Genre = genre;
            this.GenerateNewIdentity();
        }
        public Song() { }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            if (Title == null)
            {
                validationResults.Add(new ValidationResult(Messages.validation_SongTitleCannotBeNull,
                                                           new string[] { "SongTitle" }));
            }

            if (Author == null)
            {
                validationResults.Add(new ValidationResult(Messages.validation_SongAuthorCannotBeNull,
                                                           new string[] { "SongAuthor" }));
            }

            if (Album == null)
            {
                validationResults.Add(new ValidationResult(Messages.validation_SongAlbumCannotBeNull,
                                                           new string[] { "SongAlbum" }));
            }

            if (Genre == null)
            {
                validationResults.Add(new ValidationResult(Messages.validation_SongGenreCannotBeNull,
                                                           new string[] { "SongGenre" }));
            }


            return validationResults;
        }
    }
}
