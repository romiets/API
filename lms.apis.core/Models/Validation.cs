using System.Collections.Generic;

using lms.apis.core.Models.Interfaces;

namespace lms.apis.core.Models
{
    public class Validation : IValidation 
    {
        public bool HasValidationError { get; set; }
        public IEnumerable<dynamic> ValidationErrors { get; set; }
    }
}