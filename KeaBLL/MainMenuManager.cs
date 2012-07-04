using System;
using System.Collections.Generic;
using KeaBLL.General;

namespace KeaBLL
{
    public static class MainMenuManager
    {
        public static IList<MenuItem> GetAdminMainMenuList()
        {
            IList<MenuItem> result = null;
            MenuItem menuItem = null;
            result = new List<MenuItem>();
            foreach (General.AdminMainMenu item in Enum.GetValues(typeof(General.AdminMainMenu)))
            {
                menuItem = new MenuItem();
                menuItem.Item = item.ToString();
                menuItem.Controller = item.ToString();
                menuItem.Action = "Index";
                menuItem.Display = item.ToString();
                result.Add(menuItem);
            }
            return result;
        }

        public static IList<MenuItem> GetMainMenuList()
        {
            IList<MenuItem> result = null;
            MenuItem menuItem = null;
            result = new List<MenuItem>();
            foreach (General.MainMenu item in Enum.GetValues(typeof(General.MainMenu)))
            {
                menuItem = new MenuItem();
                menuItem.Item = item.ToString();
                menuItem.Controller = item.ToString();
                menuItem.Action = "Index";
                menuItem.Display = item.ToString();
                result.Add(menuItem);
            }
            return result;
        }

    }
}