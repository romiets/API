using System.Reflection;
using System.Runtime.InteropServices;
using System.Web.Http;

using lms.apis.core.Constants;

namespace lms.apis.core.Controllers
{
    [RoutePrefix(WebApiRouteAttributes.ApiHandshakeCheckRoute)]
    public class CheckController : ApiController
    {
        [Route(WebApiRouteAttributes.DefaultControllerRoute)]
        public IHttpActionResult Get()
        {
            return Ok(AssemblyGuid);
        }

        static public string AssemblyGuid
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
                return attribute.Value;
            }
        }
    }
  
}
