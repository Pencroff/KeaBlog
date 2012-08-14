using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using KeaDAL;
using ServiceLib;

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

        public static PostFull GetPostByUrl(string postUrl)
        {
            PostFull result = null;
            using (KeaContext context = new KeaContext())
            {
                result = context.PostByUrlGet(postUrl).SingleOrDefault();
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

        public static int InsertPost (Post post)
        {
            decimal? result = null;
            using (KeaContext context = new KeaContext())
            {
                result = context.PostInsert(post.Title, post.PostUrl, post.AuthorId, post.FullContent,
                                   post.Visible, post.Modified, post.SEOKeywords, post.SEODescription, post.CategoryId,
                                   post.LinkToOriginal, post.OriginalTitle).SingleOrDefault();
            }
            return (int?)result ?? 0;
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

        public static void PostAddTags(int idPost, IList<int> idTags)
        {
            string tags = idTags.EnumerableToString();
            using (KeaContext context = new KeaContext())
            {
                context.PostTagsInsert(idPost, tags);
            }
        }

        public static List<int> PostGetTags(int idPost)
        {
            List<int> result = null;
            List<int?> resultTmp;
            using (KeaContext context = new KeaContext())
            {
                resultTmp = context.TagListByPostGet(idPost).ToList();
            }
            return resultTmp.ConvertAll(new Converter<int?, int>(IntNullToInt));
        }

        private static int IntNullToInt (int? data)
        {
            return data.GetValueOrDefault();
        }

        public static List<PostShort> GetPublicPostListByPage(int startIndex, int endIndex, out int postCount)
        {
            List<PostShort> result = null;
            using (KeaContext context = new KeaContext())
            {
                ObjectParameter cnt = new ObjectParameter("count", typeof(int));
                result = context.PublicPostListByPageGet(startIndex, endIndex, cnt).ToList();
                postCount = Convert.ToInt32(cnt.Value);
            }
            return result;
        }
    }
}
