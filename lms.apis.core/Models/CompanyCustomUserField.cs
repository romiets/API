using System;
using System.Collections.Generic;

namespace lms.apis.core.Models
{
    public class CompanyCustomUserField
    {
        public int CustomUserFieldID { get; set; }
        public string Value { get; set; }
        public string TenantName { get; set; }
        public string CompanyName { get; set; }
        public int TenantID { get; set; }
        public int AllCompanies { get; set; }
        public int OwnerID { get; set; }
        public string OwnerType { get; set; }
        public bool IsActive { get; set; }
        public string FieldName { get; set; }
        public int FieldType { get; set; }
        public bool IsMandatory { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CompanyCustomUserFieldOptionList> OptionList { get; set; }
    }
}