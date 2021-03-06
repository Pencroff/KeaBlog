﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using KeaBLL;
using KeaBlog.Services.Validations;
using KeaDAL;
using Newtonsoft.Json;
using ServiceLib;
using ServiceLib.Interfaces;
using Webdiyer.WebControls.Mvc;

namespace KeaBlog.Areas.KeaAdmin.Models
{
    public class PostViewModel : ISeoModel
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
        [AllowHtml]
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

        public bool WrongModel { get; set; }

        #region Implementation of ISeoModel

        public string TitleSeo { get { return Title; } set {} }
        public string KeywordsSeo { get { return SEOKeywords; } set { } }
        public string DescriptionSeo { get { return SEODescription; } set { } }

        #endregion

        public void FillById (int postId)
        {
            WrongModel = false;
            PostFull post = PostManager.GetPostById(postId);
            if (post != null)
            {
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
            else
            {
                WrongModel = true;
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
            FullContent = WebUtility.HtmlEncode(FullContent);
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
            FullContent = WebUtility.HtmlEncode(FullContent);
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


        public string GetCutContent()
        {
            string result = WebUtility.HtmlDecode(FullContent);
            int cutIndex = result.IndexOf("<div id=\"cut\">", StringComparison.InvariantCulture);
            if (cutIndex != -1)
            {
                result = result.Substring(0, cutIndex) + "...";
            }
            return result;
        }

        public string GetFullContent()
        {
            string result = WebUtility.HtmlDecode(FullContent);
            int startIndex = result.IndexOf("<div id=\"cut\">", StringComparison.InvariantCulture);
            if (startIndex != -1)
            {
                int endindex = result.IndexOf("</div>", startIndex, StringComparison.InvariantCulture);
                if (endindex != -1)
                {
                    result = result.Substring(0, startIndex) + result.Substring(endindex+6);    
                }
            }
            return result;
        }

        public void FillByUrl(string url)
        {
            WrongModel = false;
            PostFull post = PostManager.GetPostByUrl(url);
            if (post!=null)
            {
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
            else
            {
                WrongModel = true;
            }
        }

        public string GetModifiedDateUrl()
        {
            string result = null;
            result = Modified.ToString("yyyy-MM-dd");
            return result;
        }

        public bool HasLink()
        {
            bool result = false || (this.LinkToOriginal.HasData() && this.OriginalTitle.HasData());
            return result;
        }
    }

    public class PostListViewModel : BasicModel
    {
        public PagedList<PostViewModel> Posts { get; set; }

        public Tag Tag { get; set; }
        public Category Category { get; set; }
        public string Query { get; set; }

        public bool WrongModel { get; set; }

        public void FillByPageAll (int page)
        {
            Tag = null;
            Category = null;
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
            Tag = null;
            Category = null;
            int pageSize = SettingManager.ReadSetting<int>("Page Size Public");
            int count;
            CalculateOperations.CalculatePageIndex(this, page, pageSize);
            List<PostViewModel> postList = new List<PostViewModel>();
            PostViewModel viewModel;
            List<PostFull> modelList = PostManager.GetPublicPostListByPage(StartPageIndex, EndPageIndex, out count);
            foreach (var model in modelList)
            {
                viewModel = new PostViewModel();
                ModelMapping.ModelToViewModel(model, viewModel);
                viewModel.Modified = model.Modified.ToLocalTime();
                if (model.TagsJson != null)
                {
                    viewModel.Tags = JsonConvert.DeserializeObject<List<Tag>>(model.TagsJson);
                    viewModel.SelectedTags = viewModel.Tags.Select(item => item.Id).ToList();
                }
                else
                {
                    viewModel.Tags = new List<Tag>();
                    viewModel.SelectedTags = new List<int>();
                }
                postList.Add(viewModel);
            }
            Posts = new PagedList<PostViewModel>(postList, page, pageSize, count);
            TitleSeo = "Articles kea blog";
            DescriptionSeo = "List of articles. Page: " + page;
        }

        public void FillByQueryPagePublic(string query, int page)
        {
            Tag = null;
            Category = null;
            Query = query;
            int pageSize = SettingManager.ReadSetting<int>("Page Size Public");
            int count;
            CalculateOperations.CalculatePageIndex(this, page, pageSize);
            List<PostViewModel> postList = new List<PostViewModel>();
            PostViewModel viewModel;
            List<PostFull> modelList = PostManager.GetPublicPostListByPageQuery(query, StartPageIndex, EndPageIndex, out count);
            foreach (var model in modelList)
            {
                viewModel = new PostViewModel();
                ModelMapping.ModelToViewModel(model, viewModel);
                viewModel.Modified = model.Modified.ToLocalTime();
                if (model.TagsJson != null)
                {
                    viewModel.Tags = JsonConvert.DeserializeObject<List<Tag>>(model.TagsJson);
                    viewModel.SelectedTags = viewModel.Tags.Select(item => item.Id).ToList();
                }
                else
                {
                    viewModel.Tags = new List<Tag>();
                    viewModel.SelectedTags = new List<int>();
                }
                postList.Add(viewModel);
            }
            Posts = new PagedList<PostViewModel>(postList, page, pageSize, count);
            TitleSeo = "Searched articles by query: '"+ query +"'";
            DescriptionSeo = "Search in blog by query: '"+ query +"'";
        }

        public void FillByTagPagePublic(int tagId, int page)
        {
            WrongModel = false;
            Tag = TagManager.GetTagById(tagId);
            Category = null;
            if (Tag == null)
            {
                WrongModel = true;
            }
            else
            {
                int pageSize = SettingManager.ReadSetting<int>("Page Size Public");
                int count;
                CalculateOperations.CalculatePageIndex(this, page, pageSize);
                List<PostViewModel> postList = new List<PostViewModel>();
                PostViewModel viewModel;
                List<PostFull> modelList = PostManager.GetPublicPostListByPageTag(tagId, StartPageIndex, EndPageIndex, out count);
                foreach (var model in modelList)
                {
                    viewModel = new PostViewModel();
                    ModelMapping.ModelToViewModel(model, viewModel);
                    viewModel.Modified = model.Modified.ToLocalTime();
                    if (model.TagsJson != null)
                    {
                        viewModel.Tags = JsonConvert.DeserializeObject<List<Tag>>(model.TagsJson);
                        viewModel.SelectedTags = viewModel.Tags.Select(item => item.Id).ToList();
                    }
                    else
                    {
                        viewModel.Tags = new List<Tag>();
                        viewModel.SelectedTags = new List<int>();
                    }
                    postList.Add(viewModel);
                }
                Posts = new PagedList<PostViewModel>(postList, page, pageSize, count);
                TitleSeo = "Selected articles by tag: '" + Tag.Name + "'";
                DescriptionSeo = "List of articles by tag:'" + Tag.Name + "'";
            }
        }

        public void FillByCategoryPagePublic(int categoryId, int page)
        {
            WrongModel = false;
            Tag = null;
            Category = CategoryManager.GetCategoryById(categoryId);
            if (Category == null)
            {
                WrongModel = true;
            }
            else
            {
                int pageSize = SettingManager.ReadSetting<int>("Page Size Public");
                int count;
                CalculateOperations.CalculatePageIndex(this, page, pageSize);
                List<PostViewModel> postList = new List<PostViewModel>();
                PostViewModel viewModel;
                List<PostFull> modelList = PostManager.GetPublicPostListByPageCategory(categoryId, StartPageIndex, EndPageIndex, out count);
                foreach (var model in modelList)
                {
                    viewModel = new PostViewModel();
                    ModelMapping.ModelToViewModel(model, viewModel);
                    viewModel.Modified = model.Modified.ToLocalTime();
                    if (model.TagsJson != null)
                    {
                        viewModel.Tags = JsonConvert.DeserializeObject<List<Tag>>(model.TagsJson);
                        viewModel.SelectedTags = viewModel.Tags.Select(item => item.Id).ToList();
                    }
                    else
                    {
                        viewModel.Tags = new List<Tag>();
                        viewModel.SelectedTags = new List<int>();
                    }
                    postList.Add(viewModel);
                }
                Posts = new PagedList<PostViewModel>(postList, page, pageSize, count);
                TitleSeo = "Selected articles by category: '" + Category.Name + "'";
                DescriptionSeo = "List of articles by category:'" + Category.Name + "'";
            }
        }
    }
}