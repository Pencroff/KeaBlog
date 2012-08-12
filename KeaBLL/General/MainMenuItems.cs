namespace KeaBLL.General
{
    public enum MainMenu
    {
        Blog,
        //Service,
        //Project,
        Contact
    }

    public enum AdminMainMenu
    {
        Blog,
        Category,
        Tag,
        //Service,
        //Project,
        Setting
    }

    public class MenuItem
    {
        public string Item { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Display { get; set; }
    }
}