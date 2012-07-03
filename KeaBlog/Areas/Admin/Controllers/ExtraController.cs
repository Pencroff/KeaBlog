using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeaBLL;
using KeaBLL.General;
using KeaBlog.Areas.Admin.Models;
using ServiceLib.Interfaces;

namespace KeaBlog.Areas.Admin.Controllers
{
    public class ExtraController : Controller
    {
        public ActionResult MainMenu()
        {
            IMenu<MenuItem> model = new MenuModel();
            model.Items = MainMenuManager.GetAdminMainMenuList();
            model.ActiveItem = null;
            // ToDo do not use check recuest
            foreach (var item in model.Items)
            {
                if (Request.Path.Contains(item.Item))
                {
                    model.ActiveItem = item;
                }
            }
            return PartialView(model);
        }
    }
}
