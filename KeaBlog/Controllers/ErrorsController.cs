using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeaBlog.Controllers
{
    public class ErrorsController : Controller
    {
        //
        // GET: /Errors/

        public ActionResult NotFound()
        {
            ActionResult result;
            object model = Request.Url.PathAndQuery;
            result = View(model);
            return result;
        }

    }
}
