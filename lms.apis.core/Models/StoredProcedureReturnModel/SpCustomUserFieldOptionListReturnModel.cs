using System;

namespace lms.apis.core.Models.StoredProcedureReturnModel
{
    public class SpCustomUserFieldOptionListReturnModel
    {
        public int CustomUserFieldOptionID { get; set; }
        public int CustomUserFieldID { get; set; }
        public string Option { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}