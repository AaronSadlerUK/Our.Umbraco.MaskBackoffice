using System.Web.Mvc;

namespace Our.Umbraco.MaskBackoffice.Controllers
{
    public class MaskBackofficeRouteController : Controller
    {
        public ActionResult Default()
        {
            return new HttpNotFoundResult();
        }
    }
}
