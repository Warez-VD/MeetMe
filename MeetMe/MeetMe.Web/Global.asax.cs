using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MeetMe.Web.App_Start;

namespace MeetMe.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            EnginesConfig.RemoveWebFormsEngine();
            DbConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMapper(Assembly.Load("MeetMe.Web.Models"));
        }
    }
}
