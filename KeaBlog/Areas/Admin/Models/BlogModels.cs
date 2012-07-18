using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeaBLL;
using KeaBlog.Services;
using KeaDAL;
using ServiceLib;

namespace KeaBlog.Areas.Admin.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EntryUrl { get; set; }
        public Nullable<System.Guid> AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ShortContent { get; set; }
        //[AllowHtml]
        public string FullContent { get; set; }
        public bool Visible { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string SEOKeywords { get; set; }
        public string SEODescription { get; set; }

        public void FillById (int postId)
        {
            PostFull model = PostManager.GetPostById(postId);
            ModelMapping.PostFullToViewModel(model, this);
        }

        public void SaveToDb()
        {
            Post post = new Post();
            if (this.ShortContent == null)
            {
                this.ShortContent = this.FullContent;
            }
            ModelMapping.PostViewModelToModel(this, post);
            PostManager.UpdatePost(post);

        }
        
        public string GetModifiedDate()
        {
            string result = null;
            DateTime date = Modified == null ? DateTime.Now : Modified.Value;
            result = date.ToString("dd.MM.yyyy");
            return result;
        }

        public string GetModifiedTime()
        {
            string result = null;
            DateTime date = Modified == null ? DateTime.Now : Modified.Value;
            result = date.ToString("hh:mm");
            return result;
        }

        public void DeleteById(int id)
        {
            PostManager.DeletePostById(id);
        }
    }

    public class PostListViewModel : BasicModel
    {
        public IList<PostViewModel> Posts { get; set; }

        public void FillByPage (int page)
        {
            // ToDo get PageSize from options/settings
            int pageSize = 10;
            int count;
            CalculateOperations.CalculatePageIndex(this, page, pageSize);
            Posts = new List<PostViewModel>();
            PostViewModel viewModel;
            List<PostShort> modelList = PostManager.GetPostListByPage(StartPageIndex, EndPageIndex, out count);
            foreach (var model in modelList)
            {
                viewModel = new PostViewModel();
                ModelMapping.PostShortToViewModel(model, viewModel);
                Posts.Add(viewModel);
            }
        }
    }
}