//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace KeaDAL
{
    public partial class Auth_Role
    {
        public Auth_Role()
        {
            this.Auth_User = new HashSet<Auth_User>();
        }
    
        public int Id { get; set; }
        public string Role { get; set; }
    
        public virtual ICollection<Auth_User> Auth_User { get; set; }
    }
    
}