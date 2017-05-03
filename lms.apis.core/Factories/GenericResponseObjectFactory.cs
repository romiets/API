using System;

using lms.apis.core.Constants;
using lms.apis.core.Models;
using static lms.apis.core.UnityConfig;

namespace lms.apis.core.Factories
{
    public class GenericResponseObjectFactory : IGenericResponseObjectFactory
    {
        public ResponseObject<T> Make<T>(Func<T> method)
        {
            try
            {
                var data = method();
                return InstanceProvider.GetInstance<ResponseObject<T>, T>(data);
            }
            catch 
            {
                var response = InstanceProvider.GetInstance<ResponseObject<T>>();
                response.Errors.Add(Errors.Keys.Unknown, Errors.Values.Unknown);
                return response;
            }
        }
    }

    public class ResponseObjectFactory : GenericResponseObjectFactory
    {
        public static string HttpErrors { get; private set; }

        public static new ResponseObject<T> Make<T>(Func<T> method)
        {
            return Make(method);
        }
    }
}