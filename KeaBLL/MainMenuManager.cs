using System;
using System.Collections.Generic;

namespace KeaBLL
{
    public static class MainMenuManager
    {
        public static IList<string> getMainMenuList ()
        {
            IList<string> result = null;
            result = new List<string>();
            foreach (General.AdminMainMenu item in Enum.GetValues(typeof(General.AdminMainMenu)))
            {
                result.Add(item.ToString());
            }
            return result;
        }
    }
}