using System;
using System.Data.Entity.Validation;
using KeaDAL;
using ServiceLib;
using System.Linq;

namespace KeaBLL
{
    public static class UserManager
    {
        public static Auth_User CreateUser(Auth_User user)
        {
            Auth_User result = null;
            using (KeaContext context = new KeaContext())
            {
                if (user.Id == Guid.Empty)
                {
                    user.Id = Guid.NewGuid();
                }
                try
                {
                    context.Auth_User.Add(user);
                    result = user;
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    result = null;
                    throw ex;
                    //var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                    //this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    //return View();
                }
            }
            return result;
        }

        public static Auth_User GetUser (string login)
        {
            Auth_User result = null;
            using (KeaContext context = new KeaContext())
            {
                result = context.UserByLoginGet(login).SingleOrDefault();
            }
            return result;
        }

        public static Auth_User GetUserByLoginPass(string login, string password)
        {
            Auth_User result = GetUser(login);
            if (SecurityOperations.CheckPass(password, result.PassHash, result.PassSalt))
            {
                return result;
            }
            return null;
        }

        public static bool ChangePassword(string login, string oldPassword, string newPassword)
        {
            bool result = false;
            using (KeaContext context = new KeaContext())
            {
                var user = context.UserByLoginGet(login).SingleOrDefault();
                if (user!=null)
                {
                    if (SecurityOperations.CheckPass(oldPassword, user.PassHash, user.PassSalt))
                    {
                        user.PassHash = SecurityOperations.ChangePassHash(newPassword, user.PassSalt);
                        context.SaveChanges();
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
