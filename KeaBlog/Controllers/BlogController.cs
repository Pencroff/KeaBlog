using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeaBlog.Areas.Admin.Models;

namespace KeaBlog.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index(int page = 1)
        {
            PostListViewModel viewModel = new PostListViewModel();
            viewModel.FillByPagePublic(page);
            return View(viewModel);
        }

        public ActionResult Post(string date, string url)
        {
            PostViewModel viewModel = new PostViewModel();
            viewModel.FillByUrl(url);
            return View(viewModel);
        }

        public ActionResult Tag(string date, string url)
        {
            return RedirectToAction("Post");
        }

    }
}
