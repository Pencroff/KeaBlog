using ServiceLib.Interfaces;

namespace ServiceLib
{
    public static class CalculateOperations
    {
        public static void CalculatePageIndex(IPagedModel model, int page, int pageSize)
        {
            model.StartPageIndex = page > 1 ? (page - 1) * pageSize + 1 : 0;
            model.EndPageIndex = page > 1 ? (model.StartPageIndex + pageSize) - 1 : model.StartPageIndex + pageSize;
        }
    }
}