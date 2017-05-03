using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lms.apis.core.Models.Definitions
{
    [Table("Role")]
    public class Role
    {
        [Key, Column(Order = 0)]        
        public int RoleID { get; set; }
        public string OwnerType { get; set; }
        public int OwnerID { get; set; }
        public string Name { get; set; }
        public int AccessID { get; set; }
        public Nullable<int> CreatedByUserID { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<bool> IsSystem { get; set; }
        public Nullable<bool> IsManager { get; set; }
    }
}