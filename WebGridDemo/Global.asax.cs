using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using WebGridDemo.Data;

namespace WebGridDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new StudentInitializer());
        }
    }
}
