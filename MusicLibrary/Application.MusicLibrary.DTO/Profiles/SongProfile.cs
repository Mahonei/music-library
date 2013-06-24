
using AutoMapper;
using MusicManager.Application.MusicLibrary.DTO.SongModule;
using MusicManager.Domain.MusicLibrary.SongModule.Aggregates.SongAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Application.MusicLibrary.DTO.Profiles
{
   public class SongProfile:Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Song, SongDTO>();
        }
    }
}
