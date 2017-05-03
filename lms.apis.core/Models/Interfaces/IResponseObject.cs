using System;
using System.Collections.Generic;
using System.Linq;
namespace lms.apis.core.Models.Interfaces
{
    public interface IResponseObject<T>
    {
        T Result { get; set; }
        Dictionary<string, string> Errors { get; set; }
        bool IsSuccess { get; set; }
    }
}
