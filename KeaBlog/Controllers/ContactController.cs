using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLib;

namespace KeaBlog.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            var viewModel = new BasicModel();
            viewModel.DescriptionSeo = "Sergey Danilov's blog. You can read here about web development. How you can use HTM5, CSS3 and JavaScript.";
            viewModel.KeywordsSeo = "Sergey Danilov, C#, Csharp, HTML, HTML5, CSS, CSS3, JavaScript";
            viewModel.TitleSeo = "Contact Sergey Danilov";
            return View(viewModel);
        }

    }
}
