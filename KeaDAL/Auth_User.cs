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
    public partial class Auth_User
    {
        public Auth_User()
        {
            this.Entries = new HashSet<Entry>();
            this.Auth_Role = new HashSet<Auth_Role>();
        }
    
        public System.Guid Id { get; set; }
        public string Login { get; set; }
        public string PassHash { get; set; }
        public string PassSalt { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    
        public virtual ICollection<Entry> Entries { get; set; }
        public virtual ICollection<Auth_Role> Auth_Role { get; set; }
    }
    
}