namespace ServiceLib.Interfaces
{
    public interface IPagedModel
    {
        int Page { get; set; }
        int StartPageIndex { get; set; }
        int EndPageIndex { get; set; }
    }
}
