using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceLib.Interfaces;

namespace KeaBlog.Areas.Admin.Models
{
    public class MenuModel : IMenu<string>
    {
        #region Implementation of IMenu<string>

        public IList<string> Items { get; set; }
        public string ActiveItem { get; set; }

        #endregion
    }
}