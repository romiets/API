using System.Data.Entity;
using System.Web.Http;

using lms.apis.core.Entities.Core;

namespace lms.apis.core
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            Database.SetInitializer<ApiDbContext>(null);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
