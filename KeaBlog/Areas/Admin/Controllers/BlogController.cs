using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using KeaBLL;
using KeaBlog.Areas.Admin.Models;
using KeaDAL;

namespace KeaBlog.Areas.Admin.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {

        public ActionResult Index(int id = 0)
        {
            var viewModel = new PostListViewModel();
            viewModel.FillByPage(id);
            return View(viewModel.Posts);
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
            ViewBag.AuthorId = Guid.Empty;//new SelectList(db.Auth_User, "Id", "Login");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                // Work
                //post.AuthorId = Guid.Parse("E21486DE-07F0-4E9B-BC61-B49ADEFBBCD3");
                // Home
                post.AuthorId = Guid.Parse("29A6A9E3-AF2D-4FB1-A3A5-7837DEA26003");
                PostManager.InsertPost(post);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = Guid.Empty;
            return View(post);
        }
        
        public ActionResult Edit(int id = 0)
        {
            PostViewModel viewModel = new PostViewModel();
            viewModel.FillById(id);
            if (viewModel.Id != id)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult Edit(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SaveToDb();
                return RedirectToAction("Index");
            }
            return View(model);
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