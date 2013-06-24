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
    public class HomeController : Controller
    {
        readonly ISongService _songService;
        public HomeController(ISongService songService) {
            this._songService = songService;
        }
        public ActionResult Index()
        {
            

            ViewBag.Message = "Modifique esta plantilla para poner en marcha su aplicación ASP.NET MVC.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Página de descripción de la aplicación.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto.";

            return View();
        }
    }
}
