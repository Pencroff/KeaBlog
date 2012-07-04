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
    public partial class Post
    {
        public Post()
        {
            this.Categories = new HashSet<Category>();
            this.Tags = new HashSet<Tag>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string EntryUrl { get; set; }
        public Nullable<System.Guid> AuthorId { get; set; }
        public string ShortContent { get; set; }
        public string FullContent { get; set; }
        public bool Visible { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string SEOKeywords { get; set; }
        public string SEODescription { get; set; }
    
        public virtual Auth_User auth_Users { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
    
}
