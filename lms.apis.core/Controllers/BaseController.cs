using System;
using System.Collections.Generic;
using System.Web.Http;

using lms.apis.core.Models;
using lms.apis.core.Entities;

namespace lms.apis.core.Controllers
{
    public class BaseController : ApiController
    {
        private readonly IDbContext dbContext;

        public BaseController(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
