using FluentValidation;
using Microsoft.Practices.Unity;
using System;

namespace lms.apis.core.Factories
{
    public class ModelValidatorFactory : ValidatorFactoryBase
    {
        private readonly IUnityContainer _container;

        public ModelValidatorFactory(IUnityContainer container)
        {
            _container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return _container.Resolve(validatorType) as IValidator;
        }
    }
}