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
using Newtonsoft.Json;
using ServiceLib;
using Webdiyer.WebControls.Mvc;

namespace KeaBlog.Areas.Admin.Models
{
    public class PostViewModel
    {
        private List<int> _selectedTags;

        public List<Category> CategoryList { get; set; }
        public List<Tag> TagList { get; set; }

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
        public List<Tag> Tags { get; set; }
        public List<int> SelectedTags
        {
            get { return _selectedTags ?? (_selectedTags = new List<int>()); } 
            set { _selectedTags = value; }
        }

        public void FillById (int postId)
        {
            PostFull post = PostManager.GetPostById(postId);
            ModelMapping.ModelToViewModel(post, this);
            Modified = post.Modified.ToLocalTime();
            if (post.TagsJson != null)
            {
                Tags = JsonConvert.DeserializeObject<List<Tag>>(post.TagsJson);
                SelectedTags = Tags.Select(item => item.Id).ToList();
            }
            else
            {
                Tags = new List<Tag>();
                SelectedTags = new List<int>();
            }
        }

        public void FillCategoryList()
        {
            CategoryList = CategoryManager.GetCategoryList();
        }

        public void FillTagList()
        {
            TagList = TagManager.GetTagList();
        }

        public void DbUpdate()
        {
            Post post = new Post();
            ModelMapping.ViewModelToModel(this, post);
            post.Modified = Modified.ToUniversalTime();
            post.PostUrl = PostUrl.ToTranslit().Slugify(256);
            PostManager.UpdatePost(post);
            PostManager.PostAddTags(Id, SelectedTags);
        }

        public void DbInsert()
        {
            int id;
            Post post = new Post();
            ModelMapping.ViewModelToModel(this, post);
            post.Modified = Modified.ToUniversalTime();
            post.PostUrl = PostUrl.ToTranslit().Slugify(256);
            id = PostManager.InsertPost(post);
            if (id != 0)
            {
                PostManager.PostAddTags(id, SelectedTags);
            }
        }

        public void DeleteById(int id)
        {
            PostManager.DeletePostById(id);
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

        
    }

    public class PostListViewModel : BasicModel
    {
        public PagedList<PostViewModel> Posts { get; set; }

        public void FillByPageAll (int page)
        {
            int pageSize = SettingManager.ReadSetting<int>("Page Size");
            int count;
            CalculateOperations.CalculatePageIndex(this, page, pageSize);
            List<PostViewModel> postList = new List<PostViewModel>();
            PostViewModel viewModel;
            List<PostShort> modelList = PostManager.GetPostListByPage(StartPageIndex, EndPageIndex, out count);
            foreach (var model in modelList)
            {
                viewModel = new PostViewModel();
                ModelMapping.ModelToViewModel(model, viewModel);
                viewModel.Modified = model.Modified.ToLocalTime();
                postList.Add(viewModel);
            }
            Posts = new PagedList<PostViewModel>(postList, page, pageSize, count);
        }

        public void FillByPagePublic(int page)
        {
            int pageSize = SettingManager.ReadSetting<int>("Page Size Public");
            int count;
            CalculateOperations.CalculatePageIndex(this, page, pageSize);
            List<PostViewModel> postList = new List<PostViewModel>();
            PostViewModel viewModel;
            List<PostShort> modelList = PostManager.GetPublicPostListByPage(StartPageIndex, EndPageIndex, out count);
            foreach (var model in modelList)
            {
                viewModel = new PostViewModel();
                ModelMapping.ModelToViewModel(model, viewModel);
                viewModel.Modified = model.Modified.ToLocalTime();
                postList.Add(viewModel);
            }
            Posts = new PagedList<PostViewModel>(postList, page, pageSize, count);
        }
    }
}