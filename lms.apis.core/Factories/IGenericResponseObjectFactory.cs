using System;
using lms.apis.core.Models;

namespace lms.apis.core.Factories
{
    public interface IGenericResponseObjectFactory
    {
        ResponseObject<T> Make<T>(Func<T> method);
    }
}
