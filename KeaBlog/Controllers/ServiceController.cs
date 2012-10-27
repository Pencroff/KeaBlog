using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLib;

namespace KeaBlog.Controllers
{
    public class ServiceController : Controller
    {
        //
        // GET: /Service/

        public ActionResult Index()
        {
            var viewModel = new BasicModel();
            viewModel.DescriptionSeo = "Text shadow generator. Make css3 text-shadow collection of property.";
            viewModel.KeywordsSeo = "text shadow generator, text shadow css3, Single page app, backbone.js, css3";
            viewModel.TitleSeo = "CSS3 text shadow generator";
            return View(viewModel);
        }

    }
}
