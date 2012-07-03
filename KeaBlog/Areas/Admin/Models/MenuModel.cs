using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeaBLL.General;
using ServiceLib.Interfaces;

namespace KeaBlog.Areas.Admin.Models
{
    public class MenuModel : IMenu<MenuItem>
    {
        #region Implementation of IMenu<string>

        public IList<MenuItem> Items { get; set; }
        public MenuItem ActiveItem { get; set; }

        #endregion
    }
}