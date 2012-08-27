using System.Collections.Generic;
using KeaBLL;
using KeaDAL;

namespace KeaBlog.Models
{
    public class ColumnModel
    {
        private Dictionary<string, object> _dictionary;
        public Dictionary<string, object> Dictionary { 
            get { return _dictionary ?? (_dictionary = new Dictionary<string, object>()); }
            set { _dictionary = value; }
        }

        public void FillTags ()
        {
            var tagList = TagManager.GetTagListTop();
            Dictionary.Add("_TagList", tagList);
        }

        public void FilCategories ()
        {
            List<CategoryTop> categoryList = CategoryManager.GetCategoryListTop();
            Dictionary.Add("_CategoryList", categoryList);
        }

    }
}