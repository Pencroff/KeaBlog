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
            IMenu<string> model = new MenuModel();
            model.Items = MainMenuManager.getMainMenuList();
            model.ActiveItem = AdminMainMenu.Blog.ToString();
            return PartialView(model);
        }
    }
}
