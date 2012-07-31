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
    
        public virtual int PostDelete(Nullable<int> postId)
        {
            var postIdParameter = postId.HasValue ?
                new ObjectParameter("postId", postId) :
                new ObjectParameter("postId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PostDelete", postIdParameter);
        }
    
        public virtual int PostInsert(string title, string postUrl, Nullable<System.Guid> authorId, string fullContent, Nullable<bool> visible, Nullable<System.DateTime> modified, string seoKeywords, string seoDescription, Nullable<int> categoryId, string linkToOriginal, string originalTitle)
        {
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var postUrlParameter = postUrl != null ?
                new ObjectParameter("postUrl", postUrl) :
                new ObjectParameter("postUrl", typeof(string));
    
            var authorIdParameter = authorId.HasValue ?
                new ObjectParameter("authorId", authorId) :
                new ObjectParameter("authorId", typeof(System.Guid));
    
            var fullContentParameter = fullContent != null ?
                new ObjectParameter("fullContent", fullContent) :
                new ObjectParameter("fullContent", typeof(string));
    
            var visibleParameter = visible.HasValue ?
                new ObjectParameter("visible", visible) :
                new ObjectParameter("visible", typeof(bool));
    
            var modifiedParameter = modified.HasValue ?
                new ObjectParameter("modified", modified) :
                new ObjectParameter("modified", typeof(System.DateTime));
    
            var seoKeywordsParameter = seoKeywords != null ?
                new ObjectParameter("seoKeywords", seoKeywords) :
                new ObjectParameter("seoKeywords", typeof(string));
    
            var seoDescriptionParameter = seoDescription != null ?
                new ObjectParameter("seoDescription", seoDescription) :
                new ObjectParameter("seoDescription", typeof(string));
    
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("categoryId", categoryId) :
                new ObjectParameter("categoryId", typeof(int));
    
            var linkToOriginalParameter = linkToOriginal != null ?
                new ObjectParameter("linkToOriginal", linkToOriginal) :
                new ObjectParameter("linkToOriginal", typeof(string));
    
            var originalTitleParameter = originalTitle != null ?
                new ObjectParameter("originalTitle", originalTitle) :
                new ObjectParameter("originalTitle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PostInsert", titleParameter, postUrlParameter, authorIdParameter, fullContentParameter, visibleParameter, modifiedParameter, seoKeywordsParameter, seoDescriptionParameter, categoryIdParameter, linkToOriginalParameter, originalTitleParameter);
        }
    
        public virtual int PostUpdate(Nullable<int> postId, string title, string postUrl, string fullContent, Nullable<bool> visible, Nullable<System.DateTime> modified, string seoKeywords, string seoDescription, Nullable<int> categoryId, string linkToOriginal, string originalTitle)
        {
            var postIdParameter = postId.HasValue ?
                new ObjectParameter("postId", postId) :
                new ObjectParameter("postId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var postUrlParameter = postUrl != null ?
                new ObjectParameter("postUrl", postUrl) :
                new ObjectParameter("postUrl", typeof(string));
    
            var fullContentParameter = fullContent != null ?
                new ObjectParameter("fullContent", fullContent) :
                new ObjectParameter("fullContent", typeof(string));
    
            var visibleParameter = visible.HasValue ?
                new ObjectParameter("visible", visible) :
                new ObjectParameter("visible", typeof(bool));
    
            var modifiedParameter = modified.HasValue ?
                new ObjectParameter("modified", modified) :
                new ObjectParameter("modified", typeof(System.DateTime));
    
            var seoKeywordsParameter = seoKeywords != null ?
                new ObjectParameter("seoKeywords", seoKeywords) :
                new ObjectParameter("seoKeywords", typeof(string));
    
            var seoDescriptionParameter = seoDescription != null ?
                new ObjectParameter("seoDescription", seoDescription) :
                new ObjectParameter("seoDescription", typeof(string));
    
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("categoryId", categoryId) :
                new ObjectParameter("categoryId", typeof(int));
    
            var linkToOriginalParameter = linkToOriginal != null ?
                new ObjectParameter("linkToOriginal", linkToOriginal) :
                new ObjectParameter("linkToOriginal", typeof(string));
    
            var originalTitleParameter = originalTitle != null ?
                new ObjectParameter("originalTitle", originalTitle) :
                new ObjectParameter("originalTitle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PostUpdate", postIdParameter, titleParameter, postUrlParameter, fullContentParameter, visibleParameter, modifiedParameter, seoKeywordsParameter, seoDescriptionParameter, categoryIdParameter, linkToOriginalParameter, originalTitleParameter);
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
    
        public virtual ObjectResult<PostFull> PostByUrlGet(string postUrl)
        {
            ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace.LoadFromAssembly(typeof(PostFull).Assembly);
    
            var postUrlParameter = postUrl != null ?
                new ObjectParameter("postUrl", postUrl) :
                new ObjectParameter("postUrl", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PostFull>("PostByUrlGet", postUrlParameter);
        }
    }
}
