using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeaBlog.Areas.Admin.Models;

namespace KeaBlog.Areas.Admin.Controllers
{
    [Authorize]
    public class SettingController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new SettingListViewModel();
            viewModel.FillAll();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(SettingViewModel setting)
        {
            if (ModelState.IsValid)
            {
                setting.DbUpdate();
            }
            return RedirectToAction("Index");
        }

    }
}
