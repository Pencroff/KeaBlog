using System.Collections.Generic;
using KeaBLL.General;
using ServiceLib.Interfaces;

namespace KeaBlog.Areas.KeaAdmin.Models
{
    public class MenuModel : IMenu<MenuItem>
    {
        #region Implementation of IMenu<string>

        public IList<MenuItem> Items { get; set; }
        public MenuItem ActiveItem { get; set; }

        #endregion
    }
}