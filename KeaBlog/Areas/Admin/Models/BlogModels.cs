using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeaBLL;
using KeaBlog.Services;
using KeaDAL;
using ServiceLib;

namespace KeaBlog.Areas.Admin.Models
{
    public class PostAuthorViewModel : BasicModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EntryUrl { get; set; }
        public Nullable<System.Guid> AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ShortContent { get; set; }
        public string FullContent { get; set; }
        public bool Visible { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string SEOKeywords { get; set; }
        public string SEODescription { get; set; }

        public void FillById (int postId)
        {
            PostAuthor model = PostManager.GetPostAuthorById(postId);
            ModelMapping.PostAuthorToViewModel(model, this);
        }
    }

    public class PostAuthorListViewModel : BasicModel
    {
        public IList<PostAuthorViewModel> Posts { get; set; }

        public void FillByIndex (int page)
        {
            // ToDo get PageSize from options/settings
            int pageSize = 10;
            CalculateOperations.CalculatePageIndex(this, page, pageSize);
            Posts = new List<PostAuthorViewModel>();
            PostAuthorViewModel viewModel;
            List<PostAuthor> modelList = PostManager.GetPostAutorListByPage(StartPageIndex, EndPageIndex);
            foreach (var model in modelList)
            {
                viewModel = new PostAuthorViewModel();
                ModelMapping.PostAuthorToViewModel(model, viewModel);
                Posts.Add(viewModel);
            }
        }
    }
}