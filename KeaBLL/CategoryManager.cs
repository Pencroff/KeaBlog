using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeaDAL;
using ServiceLib;

namespace KeaBLL
{
    public static class CategoryManager
    {
        public static List<Category> GetCategoryListByPage(int startPageIndex, int endPageIndex, out int count)
        {
            throw new NotImplementedException();
        }

        public static void InsertCategory(Category category)
        {
            using (KeaContext context = new KeaContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }

        }

        public static void UpdateCategory(Category category)
        {
            Category categoryDB = null;
            using (KeaContext context = new KeaContext())
            {
                categoryDB = context.Categories.Find(category.Id);
                if (categoryDB != null)
                {
                    ModelMapping.OneToOne(category, categoryDB);
                    context.SaveChanges();   
                }
            }
        }

        public static void DeleteCategoryById(int categoryId)
        {
            Category category = null;
            using (KeaContext context = new KeaContext())
            {
                category = context.Categories.Find(categoryId);
                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }
        }
    }
}
