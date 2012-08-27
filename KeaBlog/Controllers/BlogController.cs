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

        public ActionResult Tag(int? id, int page = 1)
        {
            if (id == null) return RedirectToAction("Index", "Blog", new {page = page});
            PostListViewModel viewModel = new PostListViewModel();
            viewModel.FillByTagPagePublic(id.GetValueOrDefault(), page);
            return View("Index", viewModel);
        }

        public ActionResult Category(int? id, int page = 1)
        {
            if (id == null) return RedirectToAction("Index", "Blog", new { page = page });
            PostListViewModel viewModel = new PostListViewModel();
            viewModel.FillByCategoryPagePublic(id.GetValueOrDefault(), page);
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
