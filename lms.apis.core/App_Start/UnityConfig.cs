using FluentValidation;
using Microsoft.Practices.Unity;
using System;
using System.Web.Http;
using Unity.WebApi;

using lms.apis.core.Entities;
using lms.apis.core.Entities.Core;
using lms.apis.core.Factories;
using lms.apis.core.Helpers;
using lms.apis.core.Models;
using lms.apis.core.Models.Interfaces;

namespace lms.apis.core
{
    public static class UnityConfig
    {
        private static UnityContainer container = new UnityContainer();
        public static void RegisterComponents()
        {
            container
                .RegisterType<IDbContext, ApiDbContext>()
                .RegisterType<IValidator<User>, UserViewModelValidator>()
                .RegisterType<IValidatorFactory, ModelValidatorFactory>()
                .RegisterType<IValidation, Validation>()
                .RegisterType<IHttpActionResult, HttpActionResult>()
                .RegisterType(typeof(IResponseObject<>), typeof(ResponseObject<>))
                .RegisterType<IGenericResponseObjectFactory, GenericResponseObjectFactory>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static class InstanceProvider
        { 
            public static T GetInstance<T, V>(V param)
            {
                return container.Resolve<T>(new ParameterOverride("data", param));
            }

            public static T GetInstance<T>()
            {
                return container.Resolve<T>();
            }

            public static T GetInstance<T>(Exception e)
            {
                return container.Resolve<T>(new ParameterOverride("e", e));
            }
        }
        
    }
}