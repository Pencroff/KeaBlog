using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeaDAL;

namespace KeaBLL
{
    public static class PostManager
    {
        public static PostAuthor GetPostById(int postId)
        {
            PostAuthor result = null;
            using (KeaContext context = new KeaContext())
            {
                result = context.PostAuthorByIdGet(postId).SingleOrDefault();
            }
            return result;
        }

        public static List<PostAuthor> GetPostListByPage(int startPageIndex, int endPageIndex, out int postCount)
        {
            List<PostAuthor> result = new List<PostAuthor>();
            using (KeaContext context = new KeaContext())
            {
                postCount = 0;
                //result = context.PostAuthorByPage(startPageIndex, endPageIndex).ToList();
                //ObjectParameter cnt = new ObjectParameter("count", typeof(int));
                //result = context.SearchAuthorShortPagingGet(query, startIndex, endIndex, cnt).ToList();
                //authorCount = Convert.ToInt32(cnt.Value);
            }
            return result;
        }
    }
}
