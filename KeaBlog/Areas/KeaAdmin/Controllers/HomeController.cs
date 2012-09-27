using System.Web.Mvc;

namespace KeaBlog.Areas.KeaAdmin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
