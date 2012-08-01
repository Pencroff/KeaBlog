using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using KeaDAL;
using ServiceLib;

namespace KeaBLL
{
    public static class CategoryManager
    {
        public static List<Category> GetCategoryListByPage(int startIndex, int endIndex, out int count)
        {
            List<Category> result = null;
            using (KeaContext context = new KeaContext())
            {
                ObjectParameter cnt = new ObjectParameter("count", typeof(int));
                result = context.CategoryListByPageGet(startIndex, endIndex, cnt).ToList();
                count = Convert.ToInt32(cnt.Value);
            }
            return result;
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
