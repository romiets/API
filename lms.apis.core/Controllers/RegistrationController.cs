using System.Web.Http;

using FluentValidation;

using lms.apis.core.Constants;
using lms.apis.core.Entities;
using lms.apis.core.Models;
using lms.apis.core.Models.Interfaces;
using lms.apis.core.Factories;

namespace lms.apis.core.Controllers
{
    [RoutePrefix(WebApiRouteAttributes.SelfRegistrationRootApiRoute)]
    public class RegistrationController : BaseController
    {
        private readonly IDbContext dbContext;
        private readonly IValidator<User> userValidator;
        private readonly IValidation validation;
        private readonly IGenericResponseObjectFactory response;

        public RegistrationController(
            IDbContext dbContext,
            IValidator<User> userValidator,
            IValidation validation,
            IGenericResponseObjectFactory response
        ) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.userValidator = userValidator;
            this.validation = validation;
            this.response = response;
        }

        [HttpPost, Route(WebApiRouteAttributes.SelfRegistrationSaveApiRoute)]        
        public ResponseObject<User> Save([FromBody] User user)
        {
            return response.Make(() => SaveUser(user));
        }

        private User SaveUser(User user)
        {
            var validation = dbContext.ValidateModel(user);

            user.HasValidationError = validation.HasValidationError;
            if (validation.HasValidationError)
            {
                user.ValidationErrors = validation.ValidationErrors;
                return user;
            }
            if (user.SourceApplicationID == null)
            {
                user.SourceApplicationID = (int)Common.SourceApplication.API;
            }

            user = dbContext.SaveUser(user);

            return user;
        }

        [Route(WebApiRouteAttributes.SelfRegistrationValidateUserApiRoute)]
        [HttpPost]
        public ResponseObject<IValidation> ValidateUser([FromBody] User user)
        {
            return response.Make(() => UserValidation(user));
        }

        private IValidation UserValidation(User user)
        {

            var validator = dbContext.ValidateModel(user);

            validation.HasValidationError = validator.HasValidationError;
            if (validator.HasValidationError)
            {
                validation.ValidationErrors = validator.ValidationErrors;
            }
            return validation;

        }
    }
}