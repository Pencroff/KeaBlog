using System.Linq;
using KeaDAL;

namespace KeaBLL
{
    public static class RoleManager
    {
        public static bool IsUserInRole (string username, string role)
        {
            return false;
        }

        public static string[] RolesForUserGet(string username)
        {
            string[] result = null;
            using (KeaContext context = new KeaContext())
            {
                result = context.UserRolesGet(username).ToArray();
            }
            return result;
        }
    }
}
