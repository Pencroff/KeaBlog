using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KeaBLL;
using KeaDAL;
using ServiceLib;
using Webdiyer.WebControls.Mvc;

namespace KeaBlog.Areas.Admin.Models
{
    public class TagModels
    {
        public class TagViewModel
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Name of tag is required.")]
            public string Name { get; set; }

            public void DbInsert()
            {
                Tag tag = new Tag();
                ModelMapping.ViewModelToModel(this, tag);
                TagManager.InsertTag(tag);
            }

            public void DbUpdate()
            {
                Tag tag = new Tag();
                ModelMapping.ViewModelToModel(this, tag);
                TagManager.UpdateTag(tag);
            }

            public void DeleteById(int categoryId)
            {
                TagManager.DeleteTagById(categoryId);
            }
        }
        public class CategoryListViewModel : BasicModel
        {
            public PagedList<TagViewModel> Tags { get; set; }

            public void FillByPage(int page)
            {
                // ToDo get PageSize from options/settings
                int pageSize = 10;
                int count;
                CalculateOperations.CalculatePageIndex(this, page, pageSize);
                List<TagViewModel> tagList = new List<TagViewModel>();
                TagViewModel viewModel;
                List<Tag> modelList = TagManager.GetTagListByPage(StartPageIndex, EndPageIndex, out count);
                foreach (var model in modelList)
                {
                    viewModel = new TagViewModel();
                    ModelMapping.ModelToViewModel(model, viewModel);
                    tagList.Add(viewModel);
                }
                Tags = new PagedList<TagViewModel>(tagList, page, pageSize, count);
            }
        }
    }
}