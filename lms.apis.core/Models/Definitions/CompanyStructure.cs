using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lms.apis.core.Models.Definitions
{
    [Table("CompanyStructure_vw")]
    public class CompanyStructure
    {
        [Key, Column(Order = 0)]
        public Nullable<int> companyID { get; set; }
        [Key, Column(Order = 1)]
        public string companyName { get; set; }
        [Key, Column(Order = 2)]
        public Nullable<int> regionID { get; set; }
        [Key, Column(Order = 3)]
        public string regionName { get; set; }
        [Key, Column(Order = 4)]
        public Nullable<int> storeID { get; set; }
        [Key, Column(Order = 5)]
        public string storeName { get; set; }
        [Key, Column(Order = 6)]
        public Nullable<int> departmentID { get; set; }
        [Key, Column(Order = 7)]
        public string departmentName { get; set; }
        [Key, Column(Order = 8)]
        public string TenantName { get; set; }
        [Key, Column(Order = 9)]
        public int TenantID { get; set; }
    }
}