using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeaDAL;

namespace KeaBLL
{
    public static class PostManager
    {
        public static PostAuthor GetPostAuthorById(int postId)
        {
            PostAuthor result = null;
            using (KeaContext context = new KeaContext())
            {
                result = context.PostAuthorByIdGet(postId).SingleOrDefault();
            }
            return result;
        }
    }
}
