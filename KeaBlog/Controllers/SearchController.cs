using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeaBlog.Areas.Admin.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index(string query)
        {
            if (String.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
