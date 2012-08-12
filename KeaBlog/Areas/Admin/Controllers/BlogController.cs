using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using KeaBLL;
using KeaBlog.Areas.Admin.Models;
using KeaBlog.Services;
using KeaDAL;

namespace KeaBlog.Areas.Admin.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {

        public ActionResult Index(int page = 1)
        {
            var viewModel = new PostListViewModel();
            viewModel.FillByPage(page);
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