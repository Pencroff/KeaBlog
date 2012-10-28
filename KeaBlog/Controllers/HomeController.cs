using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLib;

namespace KeaBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new BasicModel();
            viewModel.DescriptionSeo = "Pencroff.blog. This is Sergey Danilov's blog. Blog about web development and best prictice of HTM5, CSS3, JavaScript and server side app on ASP.NET MVC.";
            viewModel.KeywordsSeo = "Pencroff, ASP.NET MVC, C#, Csharp, HTML, HTML5, CSS, CSS3, JavaScript, web-development, web-service, startup";
            viewModel.TitleSeo = "Pencroff.blog";
            return View(viewModel);
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
