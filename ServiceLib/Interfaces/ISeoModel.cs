namespace ServiceLib.Interfaces
{
    public interface ISeoModel
    {
        string SeoTitle { get; set; }
        string SeoKeywords { get; set; }
        string SeoDescription { get; set; }
    }
}