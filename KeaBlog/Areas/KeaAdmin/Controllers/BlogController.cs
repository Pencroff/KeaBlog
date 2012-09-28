using System;
using System.Web.Mvc;
using KeaBlog.Areas.KeaAdmin.Models;
using KeaBlog.Services;
using ServiceLib;

namespace KeaBlog.Areas.KeaAdmin.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {

        public ActionResult Index(int page = 1)
        {
            var viewModel = new PostListViewModel();
            viewModel.FillByPageAll(page);
            return View(viewModel);
        }
        
        public ActionResult Details(int id = 0)
        {
            PostViewModel viewModel = new PostViewModel();
            viewModel.FillById(id);
            if (viewModel.Id != id)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        public ActionResult Create()
        {
            PostViewModel viewModel = new PostViewModel();
            viewModel.Modified = DateTime.Now;
            viewModel.FillCategoryList();
            viewModel.FillTagList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(PostViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.AuthorId = Guid.Parse(CurrentSession.UserId);
                viewModel.DbInsert();
                return RedirectToAction("Index");
            }
            if (String.IsNullOrEmpty(viewModel.PostUrl))
            {
                viewModel.PostUrl = viewModel.Title.ToTranslit().Slugify(256);
            }
            viewModel.FillCategoryList();
            viewModel.FillTagList();
            return View(viewModel);
        }
        
        public ActionResult Edit(int id = 0)
        {
            PostViewModel viewModel = new PostViewModel();
            viewModel.FillById(id);
            viewModel.FillCategoryList();
            viewModel.FillTagList();
            if (viewModel.Id != id)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult Edit(PostViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.DbUpdate();
                return RedirectToAction("Index");
            }
            if (String.IsNullOrEmpty(viewModel.PostUrl))
            {
                viewModel.PostUrl = viewModel.Title.ToTranslit().Slugify(256);
            }
            viewModel.FillCategoryList();
            viewModel.FillTagList();
            return View(viewModel);
        }

        public ActionResult Delete(int id = 0)
        {
            PostViewModel viewModel = new PostViewModel();
            viewModel.FillById(id);
            if (viewModel.Id != id)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PostViewModel viewModel = new PostViewModel();
            viewModel.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}