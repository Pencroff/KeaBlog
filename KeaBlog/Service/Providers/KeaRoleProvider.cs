using System;
using System.Web.Security;
using KeaBLL;

namespace KeaBlog.Service.Providers
{
    public class KeaRoleProvider : RoleProvider
    {
        private string _app = "App";

        public override bool IsUserInRole(string username, string roleName)
        {
            return RoleManager.IsUserInRole(username, roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            return RoleManager.RolesForUserGet(username);
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { return _app; }
            set { _app = value; }
        }
    }
}