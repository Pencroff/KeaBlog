using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeaBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return RedirectToAction("Index", "Blog");
            return View();
        }

        public ActionResult Download(string fileName)
        {
            string file = Server.MapPath("~/Content/Shared/" + fileName);
            if (System.IO.File.Exists(file))
                return File("~/Content/Shared/" + fileName, "application/pdf", fileName);
            else
                return RedirectToAction("Index");
        }

        #region -- Robots() Method --
        public ActionResult Robots()
        {
            Response.ContentType = "text/plain";
            return View();
        }
        #endregion
    }
}
