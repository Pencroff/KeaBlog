using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeaBlog.Areas.Admin.Controllers
{
    [Authorize]
    public class SettingController : Controller
    {
        //
        // GET: /Admin/Setting/

        public ActionResult Index()
        {
            return View();
        }

    }
}
