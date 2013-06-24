using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using MusicManager.Presentation.ASPMVC.MusicLibrary.Models;

namespace MusicManager.Presentation.ASPMVC.MusicLibrary.Controllers
{
    public class ExtNetController : Controller
    {
        public ActionResult Index()
        {

            return this.View();
        }

        public ActionResult SampleAction(string message)
        {
            X.Msg.Notify(new NotificationConfig
            {
                Icon = Icon.Accept,
                Title = "Working",
                Html = message
            }).Show();

            return this.Direct();
        }
    }
}