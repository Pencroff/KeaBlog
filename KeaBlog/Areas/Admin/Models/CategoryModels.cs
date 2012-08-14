using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KeaBLL;
using KeaBlog.Services;
using KeaDAL;
using ServiceLib;
using Webdiyer.WebControls.Mvc;

namespace KeaBlog.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of category is required.")]
        public string Name { get; set; }
        public string Description { get; set; }

        public void DbInsert()
        {
            Category category = new Category();
            ModelMapping.ViewModelToModel(this, category);
            CategoryManager.InsertCategory(category);
        }

        public void DbUpdate()
        {
            Category category = new Category();
            ModelMapping.ViewModelToModel(this, category);
            CategoryManager.UpdateCategory(category);
        }

        public void DeleteById(int categoryId)
        {
            CategoryManager.DeleteCategoryById(categoryId);
        }
    }
    public class CategoryListViewModel : BasicModel
    {
        public PagedList<CategoryViewModel> Categories { get; set; }
        public IList<CategoryViewModel> CategoriesAll { get; set; }

        public void FillByPage (int page)
        {
            int pageSize = SettingManager.ReadSetting<int>("Page Size");
            int count;
            CalculateOperations.CalculatePageIndex(this, page, pageSize);
            CategoriesAll = new List<CategoryViewModel>();
            CategoryViewModel viewModel;
            List<Category> modelList = CategoryManager.GetCategoryListByPage(StartPageIndex, EndPageIndex, out count);
            foreach (var model in modelList)
            {
                viewModel = new CategoryViewModel();
                ModelMapping.ModelToViewModel(model, viewModel);
                CategoriesAll.Add(viewModel);
            }
            Categories = new PagedList<CategoryViewModel>(CategoriesAll, page, pageSize, count);
        }

        public void FillAll ()
        {
            CategoriesAll = new List<CategoryViewModel>();
            CategoryViewModel viewModel;
            List<Category> modelList = CategoryManager.GetCategoryList();
            foreach (var model in modelList)
            {
                viewModel = new CategoryViewModel();
                ModelMapping.ModelToViewModel(model, viewModel);
                CategoriesAll.Add(viewModel);
            }
        }
    }
}