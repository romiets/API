namespace lms.apis.core.Models
{
    public class CompanyStructure
    {
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int? RegionId { get; set; }
        public string RegionName { get; set; }
        public int? OfficeId { get; set; }
        public string OfficeName { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? TenantId { get; set; }
        public string TenantName { get; set; }
    }
}