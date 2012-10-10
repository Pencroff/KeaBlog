using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KeaBlog.Areas.KeaAdmin.Models;

namespace KeaBlog.Controllers
{
    public static class ControllerUtils
    {
        public static void ExecuteController(IController controllerInstanse, RouteData routeData)
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            var requestContext = new RequestContext(wrapper, routeData);
            controllerInstanse.Execute(requestContext);
        }
    }

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
                string resultError = String.Format("Page not found. Date:{0} URL:{1}", date, url);
                throw new HttpException(404, resultError);
            }
            return View(viewModel);
        }

        public ActionResult Tag(int? id, int page = 1)
        {
            if (id == null)
            {
                string resultError = String.Format("Page not found. Id:{0} Page:{1}", id, page);
                throw new HttpException(404, resultError);
            }
            PostListViewModel viewModel = new PostListViewModel();
            viewModel.FillByTagPagePublic(id.GetValueOrDefault(), page);
            if (viewModel.WrongModel)
            {
                string resultError = String.Format("Page not found. Id:{0} Page:{1}", id, page);
                throw new HttpException(404, resultError);
            }
            return View("Index", viewModel);
        }

        public ActionResult Category(int? id, int page = 1)
        {
            if (id == null)
            {
                string resultError = String.Format("Page not found. Id:{0} Page:{1}", id, page);
                throw new HttpException(404, resultError);
            }
            PostListViewModel viewModel = new PostListViewModel();
            viewModel.FillByCategoryPagePublic(id.GetValueOrDefault(), page);
            if (viewModel.WrongModel)
            {
                string resultError = String.Format("Page not found. Id:{0} Page:{1}", id, page);
                throw new HttpException(404, resultError);
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
