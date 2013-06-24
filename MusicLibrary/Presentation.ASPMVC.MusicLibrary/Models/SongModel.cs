using Ext.Net.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicManager.Presentation.ASPMVC.MusicLibrary.Models
{
    [Model(Name = "Song")]
    public class SongModel
    {
        [ModelField(IDProperty = true, UseNull = true)]
        [Field(Ignore = true)]
        public string Id { get; set; }

        [PresenceValidation]
        public string Title { get; set; }
        [PresenceValidation]
        public string Author { get; set; }
        [PresenceValidation]
        public string Album { get; set; }
        [PresenceValidation]
        public string Genre { get; set; }

        public static IEnumerable<SongModel> GetAll()
        {
            return new List<SongModel> { 
                new SongModel{ Id = Guid.NewGuid().ToString(), Title = "John", Author = "Snow",Album="Lolo",Genre="Hoña"}
            };
        }
    }
}