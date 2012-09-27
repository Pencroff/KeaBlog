using System.Web.Mvc;

namespace KeaBlog.Areas.KeaAdmin.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        //
        // GET: /Admin/Service/

        public ActionResult Index()
        {
            return View();
        }

    }
}
