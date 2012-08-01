using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeaBlog.Areas.Admin.Models;

namespace KeaBlog.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Admin/Category/

        public ActionResult Index(int page = 1)
        {
            var viewModel = new CategoryListViewModel();
            viewModel.FillByPage(page);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel category)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel category)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int categoryId)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
