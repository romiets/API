using System.Collections.Generic;

using lms.apis.core.Models.Interfaces;

namespace lms.apis.core.Models
{
    public class ResponseObject <T> : IResponseObject<T>
    {
        public ResponseObject()
        {
            Errors = new Dictionary<string, string>();
        }
        public ResponseObject(T data) : base()
        {
           Result = data;
        }
   
        public T Result { get; set; }
        public Dictionary<string,string> Errors { get; set; }
        public bool IsSuccess { get; set; }
    }
}