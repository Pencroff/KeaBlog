using System.Web.Mvc;

namespace KeaBlog.Areas.KeaAdmin.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        //
        // GET: /Admin/Project/

        public ActionResult Index()
        {
            return View();
        }

    }
}
