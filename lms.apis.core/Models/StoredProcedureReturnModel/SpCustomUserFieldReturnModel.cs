using System;

namespace lms.apis.core.Models.StoredProcedureReturnModel
{
    public class SpCustomUserFieldReturnModel
    {
        public int CustomUserFieldID { get; set; }
        public string Value { get; set; }
        public string TenantName { get; set; }
        public string CompanyName { get; set; }
        public int TenantID { get; set; }
        public int AllCompanies { get; set; }
        public int CustomUserFieldID1 { get; set; }
        public int OwnerID { get; set; }
        public string OwnerType { get; set; }
        public bool IsActive { get; set; }
        public string FieldName { get; set; }
        public int FieldType { get; set; }
        public bool IsMandatory { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}