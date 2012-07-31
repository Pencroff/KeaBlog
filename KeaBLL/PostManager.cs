using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using KeaDAL;

namespace KeaBLL
{
    public static class PostManager
    {
        public static PostFull GetPostById(int postId)
        {
            PostFull result = null;
            using (KeaContext context = new KeaContext())
            {
                result = context.PostByIdGet(postId).SingleOrDefault();
            }
            return result;
        }

        public static List<PostShort> GetPostListByPage(int startIndex, int endIndex, out int postCount)
        {
            List<PostShort> result = null;
            using (KeaContext context = new KeaContext())
            {
                ObjectParameter cnt = new ObjectParameter("count", typeof(int));
                result = context.PostListByPageGet(startIndex, endIndex, cnt).ToList();
                postCount = Convert.ToInt32(cnt.Value);
            }
            return result;
        }

        public static void InsertPost (Post post)
        {
            using (KeaContext context = new KeaContext())
            {
                context.PostInsert(post.Title, post.PostUrl, post.AuthorId, post.FullContent,
                                   post.Visible, post.Modified, post.SEOKeywords, post.SEODescription, post.CategoryId,
                                   post.LinkToOriginal, post.OriginalTitle);
            }
        }

        public static void UpdatePost(Post post)
        {
            using (KeaContext context = new KeaContext())
            {
                context.PostUpdate(post.Id, post.Title, post.PostUrl, post.FullContent,
                                   post.Visible, post.Modified, post.SEOKeywords, post.SEODescription,
                                   post.CategoryId, post.LinkToOriginal, post.OriginalTitle);
            }
        }

        public static void DeletePostById(int id)
        {
            using (KeaContext context = new KeaContext())
            {
                context.PostDelete(id);
            }
        }
    }
}
