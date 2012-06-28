[assembly: WebActivator.PreApplicationStartMethod(typeof(KeaBlog.App_Start.ElmahMvc), "Start")]
namespace KeaBlog.App_Start
{
    public class ElmahMvc
    {
        public static void Start()
        {
            Elmah.Mvc.Bootstrap.Initialize();
        }
    }
}