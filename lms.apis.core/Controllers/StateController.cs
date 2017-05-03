using lms.apis.core.Constants;
using lms.apis.core.Entities;
using lms.apis.core.Factories;
using lms.apis.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lms.apis.core.Controllers
{
    [RoutePrefix(WebApiRouteAttributes.StateInfoRootApiRoute)]
    public class StateController : BaseController
    {
        private readonly IDbContext dbContext;
        private readonly IGenericResponseObjectFactory response;

        public StateController(
            IDbContext dbContext,
            IGenericResponseObjectFactory response
        ) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.response = response;
        }

        [Route(WebApiRouteAttributes.StateInfoGetApiRoute)]
        public ResponseObject<IEnumerable<State>> GetList()
        {
            return response.Make(() => dbContext.GetStates());
        }

    }
}
