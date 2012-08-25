using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using KeaDAL;
using ServiceLib;

namespace KeaBLL
{
    public static class TagManager
    {
        public static List<Tag> GetTagListByPage(int startIndex, int endIndex, out int count)
        {
            List<Tag> result = null;
            using (KeaContext context = new KeaContext())
            {
                ObjectParameter cnt = new ObjectParameter("count", typeof(int));
                result = context.TagListByPageGet(startIndex, endIndex, cnt).ToList();
                count = Convert.ToInt32(cnt.Value);
            }
            return result;
        }

        public static List<TagTop> GetTagListTop(int? countTop = null)
        {
            List<TagTop> result = null;
            using (KeaContext context = new KeaContext())
            {
                result = context.TagListTopGet(countTop).ToList();
            }
            return result;
        }

        public static void InsertTag(Tag tag)
        {
            using (KeaContext context = new KeaContext())
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }

        }

        public static void UpdateTag(Tag tag)
        {
            Tag tagDB = null;
            string[] list = null;
            using (KeaContext context = new KeaContext())
            {
                tagDB = context.Tags.Find(tag.Id);
                if (tagDB != null)
                {
                    ModelMapping.OneToOne(tag, tagDB, list);
                    context.SaveChanges();
                }
            }
        }

        public static void DeleteTagById(int tagId)
        {
            Tag tag = null;
            if (tagId == 0)
            {
                return;
            }
            using (KeaContext context = new KeaContext())
            {
                tag = context.Tags.Find(tagId);
                if (tag != null)
                {
                    context.Tags.Remove(tag);
                    context.SaveChanges();
                }
            }
        }

        public static Tag GetTagByName(string tagName)
        {
            Tag result = null;
            using (KeaContext context = new KeaContext())
            {
                result = context.TagByNameGet(tagName).SingleOrDefault();
            }
            return result;
        }

        public static List<Tag> GetTagList()
        {
            List<Tag> result = null;
            using (KeaContext context = new KeaContext())
            {
                result = context.TagListGet().ToList();
            }
            return result;
        }
    }
}