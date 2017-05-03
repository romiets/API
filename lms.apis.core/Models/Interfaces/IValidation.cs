using System.Collections.Generic;

namespace lms.apis.core.Models.Interfaces
{
    public interface IValidation
    {
        bool HasValidationError { get; set; }
        IEnumerable<dynamic> ValidationErrors { get; set; }

    }
}
