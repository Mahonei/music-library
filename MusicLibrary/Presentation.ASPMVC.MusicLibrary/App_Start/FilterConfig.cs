using System.Web;
using System.Web.Mvc;

namespace MusicManager.Presentation.ASPMVC.MusicLibrary
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}