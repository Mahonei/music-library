using Ext.Net;
using Ext.Net.MVC;
using MusicaManager.Application.MusicLibrary.SongModule.Services;
using MusicManager.Application.MusicLibrary.DTO.SongModule;
using MusicManager.Presentation.ASPMVC.MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicManager.Presentation.ASPMVC.MusicLibrary.Controllers
{
  
    public class MusicController : Controller
    {
        readonly ISongService _songService;
        //
        // GET: /Music/
        public MusicController(ISongService songService) {
            _songService = songService;
        }

        public ActionResult Index()
        {
            return View(PlayListTreeModel.BuildTree());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RestResult Create(SongModel song)
        {
            try
            {

                var songDTO = _songService.AddNewSong(MaterializeSongDtoFromView(song));

                return new RestResult
                {
                    Success = true,
                    Message = "New song is added",
                    Data = MaterializeSongViewFromDTO(songDTO)
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public RestResult Read(string list)
        {
            try
            {
                List<SongDTO> songs=new List<SongDTO>();

                if (String.Compare(list, "Music", true) == 0)
                {
                    songs = _songService.FindSongs();
                }
                else {
                    songs = _songService.FindSongByGenere(list);

                }
                    
                List<SongModel> listSong= new List<SongModel>();
                if (songs != null && songs.Any())
                {
                    foreach (var song in songs)
                    {
                        listSong.Add(MaterializeSongViewFromDTO(song));
                    }

                }
                return new RestResult
                {
                    Success = true,
                    Data = listSong
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [AcceptVerbs(HttpVerbs.Put)]
        public RestResult Update(SongModel song)
        {
            try
            {

                _songService.UpdateSong(MaterializeSongDtoFromView(song));
                return new RestResult
                {
                    Success = true,
                    Message = "Song has been updated"
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public RestResult Destroy(string id)
        {
            try
            {

                _songService.RemoveSong(Guid.Parse(id));
                return new RestResult
                {
                    Success = true,
                    Message = "Song has been deleted"
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        public ActionResult AllSongs(string node)
        {
           
           var p = new Ext.Net.MVC.PartialViewResult { ViewName = "AllSongs", ContainerId = "rightPanel", ClearContainer = true, RenderMode = RenderMode.AddTo};
           p.ViewBag.List = node;
           return p;
        }

        private SongDTO MaterializeSongDtoFromView(SongModel songModel)
        {
            SongDTO songDTO = new SongDTO();
            songDTO.Id = songModel.Id == null ? Guid.Empty: Guid.Parse(songModel.Id) ;
            songDTO.Title = songModel.Title;
            songDTO.Genre = songModel.Genre;
            songDTO.Author = songModel.Author;
            songDTO.Album = songModel.Album;
            return songDTO;
        }

        private SongModel MaterializeSongViewFromDTO(SongDTO songDTO)
        {
            SongModel songModel = new SongModel();
            songModel.Id = songDTO.Id.ToString();
            songModel.Title = songDTO.Title;
            songModel.Genre = songDTO.Genre;
            songModel.Author = songDTO.Author;
            songModel.Album = songDTO.Album;
            return songModel;
        }



    }
}
