using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Application.MusicLibrary.DTO.SongModule
{
    public class SongDTO
    {
        public Guid Id {get; set;}
        public string Title { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
    }
}
