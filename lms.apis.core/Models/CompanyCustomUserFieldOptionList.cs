using System;

namespace lms.apis.core.Models
{
    public class CompanyCustomUserFieldOptionList
    {
        public int CustomUserFieldOptionID { get; set; }
        public int CustomUserFieldID { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}