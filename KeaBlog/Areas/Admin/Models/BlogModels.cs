using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeaBLL;
using KeaBlog.Services;
using KeaBlog.Services.Validations;
using KeaDAL;
using ServiceLib;
using Webdiyer.WebControls.Mvc;

namespace KeaBlog.Areas.Admin.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title of article is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Friendly Url isn't empty.")]
        [FriendlyUrlValidation]
        public string PostUrl { get; set; }
        public System.Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string FullContent { get; set; }
        public bool Visible { get; set; }
        public System.DateTime Modified { get; set; }
        public string SEOKeywords { get; set; }
        public string SEODescription { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string LinkToOriginal { get; set; }
        public string OriginalTitle { get; set; }

        public void FillById (int postId)
        {
            PostFull post = PostManager.GetPostById(postId);
            //ModelMapping.PostFullToViewModel(post, this);
            ModelMapping.ModelToViewModel(post, this);
            Modified = post.Modified.ToLocalTime();
        }

        public void SaveToDb()
        {
            Post post = new Post();
            //ModelMapping.PostViewModelToModel(this, post);
            ModelMapping.ViewModelToModel(this, post);
            post.Modified = Modified.ToUniversalTime();
            post.PostUrl = PostUrl.ToTranslit().Slugify(256);
            PostManager.UpdatePost(post);
        }

        public void InsertToDb()
        {
            Post post = new Post();
            //ModelMapping.PostViewModelToModel(this, post);
            ModelMapping.ViewModelToModel(this, post);
            post.Modified = Modified.ToUniversalTime();
            post.PostUrl = PostUrl.ToTranslit().Slugify(256);
            PostManager.InsertPost(post);
        }
        
        public string GetModifiedDate()
        {
            string result = null;
            result = Modified.ToString("dd.MM.yyyy");
            return result;
        }

        public string GetModifiedTime()
        {
            string result = null;
            result = Modified.ToString("HH:mm");
            return result;
        }

        public void DeleteById(int id)
        {
            PostManager.DeletePostById(id);
        }
    }

    public class PostListViewModel : BasicModel
    {
        public PagedList<PostViewModel> Posts { get; set; }

        public void FillByPage (int page)
        {
            // ToDo get PageSize from options/settings
            int pageSize = 10;
            int count;
            CalculateOperations.CalculatePageIndex(this, page, pageSize);
            List<PostViewModel> postList = new List<PostViewModel>();
            PostViewModel viewModel;
            List<PostShort> modelList = PostManager.GetPostListByPage(StartPageIndex, EndPageIndex, out count);
            foreach (var model in modelList)
            {
                viewModel = new PostViewModel();
                //ModelMapping.PostShortToViewModel(model, viewModel);
                ModelMapping.ModelToViewModel(model, viewModel);
                viewModel.Modified = model.Modified.ToLocalTime();
                postList.Add(viewModel);
            }
            Posts = new PagedList<PostViewModel>(postList, page, pageSize, count);
        }
    }
}