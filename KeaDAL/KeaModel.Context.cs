﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace KeaDAL
{
    public partial class KeaContext : DbContext
    {
        public KeaContext()
            : base("name=KeaContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Auth_Role> Auth_Role { get; set; }
        public DbSet<Auth_User> Auth_User { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    
        public virtual ObjectResult<Auth_User> UserByLoginGet(string login)
        {
            ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace.LoadFromAssembly(typeof(Auth_User).Assembly);
    
            var loginParameter = login != null ?
                new ObjectParameter("login", login) :
                new ObjectParameter("login", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Auth_User>("UserByLoginGet", loginParameter);
        }
    
        public virtual ObjectResult<Auth_User> UserByLoginGet(string login, MergeOption mergeOption)
        {
            ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace.LoadFromAssembly(typeof(Auth_User).Assembly);
    
            var loginParameter = login != null ?
                new ObjectParameter("login", login) :
                new ObjectParameter("login", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Auth_User>("UserByLoginGet", mergeOption, loginParameter);
        }
    
        public virtual ObjectResult<string> UserRolesGet(string login)
        {
            var loginParameter = login != null ?
                new ObjectParameter("login", login) :
                new ObjectParameter("login", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("UserRolesGet", loginParameter);
        }
    
        public virtual ObjectResult<PostFull> PostByIdGet(Nullable<int> postId)
        {
            ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace.LoadFromAssembly(typeof(PostFull).Assembly);
    
            var postIdParameter = postId.HasValue ?
                new ObjectParameter("postId", postId) :
                new ObjectParameter("postId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PostFull>("PostByIdGet", postIdParameter);
        }
    
        public virtual ObjectResult<PostShort> PostListByPageGet(Nullable<int> startIndex, Nullable<int> endIndex, ObjectParameter count)
        {
            ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace.LoadFromAssembly(typeof(PostShort).Assembly);
    
            var startIndexParameter = startIndex.HasValue ?
                new ObjectParameter("startIndex", startIndex) :
                new ObjectParameter("startIndex", typeof(int));
    
            var endIndexParameter = endIndex.HasValue ?
                new ObjectParameter("endIndex", endIndex) :
                new ObjectParameter("endIndex", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PostShort>("PostListByPageGet", startIndexParameter, endIndexParameter, count);
        }
    
        public virtual int PostInsert(string title, string entryUrl, Nullable<System.Guid> authorId, string shortContent, string fullContent, Nullable<bool> visible, Nullable<System.DateTime> created, Nullable<System.DateTime> modified, string seoKeywords, string seoDescription)
        {
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var entryUrlParameter = entryUrl != null ?
                new ObjectParameter("entryUrl", entryUrl) :
                new ObjectParameter("entryUrl", typeof(string));
    
            var authorIdParameter = authorId.HasValue ?
                new ObjectParameter("authorId", authorId) :
                new ObjectParameter("authorId", typeof(System.Guid));
    
            var shortContentParameter = shortContent != null ?
                new ObjectParameter("shortContent", shortContent) :
                new ObjectParameter("shortContent", typeof(string));
    
            var fullContentParameter = fullContent != null ?
                new ObjectParameter("fullContent", fullContent) :
                new ObjectParameter("fullContent", typeof(string));
    
            var visibleParameter = visible.HasValue ?
                new ObjectParameter("visible", visible) :
                new ObjectParameter("visible", typeof(bool));
    
            var createdParameter = created.HasValue ?
                new ObjectParameter("created", created) :
                new ObjectParameter("created", typeof(System.DateTime));
    
            var modifiedParameter = modified.HasValue ?
                new ObjectParameter("modified", modified) :
                new ObjectParameter("modified", typeof(System.DateTime));
    
            var seoKeywordsParameter = seoKeywords != null ?
                new ObjectParameter("seoKeywords", seoKeywords) :
                new ObjectParameter("seoKeywords", typeof(string));
    
            var seoDescriptionParameter = seoDescription != null ?
                new ObjectParameter("seoDescription", seoDescription) :
                new ObjectParameter("seoDescription", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PostInsert", titleParameter, entryUrlParameter, authorIdParameter, shortContentParameter, fullContentParameter, visibleParameter, createdParameter, modifiedParameter, seoKeywordsParameter, seoDescriptionParameter);
        }
    }
}
