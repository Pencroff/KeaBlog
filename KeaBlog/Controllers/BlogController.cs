using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeaBlog.Areas.KeaAdmin.Models;

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
            if (!viewModel.Visible || viewModel.WrongModel)
            {
                Response.StatusCode = 404;
                Response.Clear();
                return View("../Errors/NotFound"); ;
            }
            return View(viewModel);
        }

        public ActionResult Tag(int? id, int page = 1)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                Response.Clear();
                return View("../Errors/NotFound"); ;
            }
            PostListViewModel viewModel = new PostListViewModel();
            viewModel.FillByTagPagePublic(id.GetValueOrDefault(), page);
            if (viewModel.WrongModel)
            {
                Response.StatusCode = 404;
                Response.Clear();
                return View("../Errors/NotFound"); ;
            }
            return View("Index", viewModel);
        }

        public ActionResult Category(int? id, int page = 1)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                Response.Clear();
                return View("../Errors/NotFound"); ;
            }
            PostListViewModel viewModel = new PostListViewModel();
            viewModel.FillByCategoryPagePublic(id.GetValueOrDefault(), page);
            if (viewModel.WrongModel)
            {
                Response.StatusCode = 404;
                Response.Clear();
                return View("../Errors/NotFound"); ;
            }
            return View("Index", viewModel);
        }

        public ActionResult Search(string query, int page = 1)
        {
            if (String.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index", "Blog");
            }
            var viewModel = new PostListViewModel();
            viewModel.FillByQueryPagePublic(query, page);
            return View("Index", viewModel);
        }

    }
}
