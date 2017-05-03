using System;

namespace lms.apis.core.Models.Interfaces
{
    public interface IUser
    {
        int UserID { get; set; }
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Suburb { get; set; }
        int? StateID { get; set; }
        string PostCode { get; set; }
        string CountryCode { get; set; }
        string PhoneNumber { get; set; }
        DateTime? UserMadeInactiveOnDate { get; set; }
        int SupplierID { get;  }
        bool IsActive { get; set; }
        int CreatedByUserID { get; }
        DateTime? CreatedDate { get; set; }
         DateTime? DateMadeInactive { get; set; }
        int? DeactivatedByUserID { get; set; }
        int TenantID { get; set; }
        int? CompanyID { get; set; }
        int? RegionID { get; set; }
        int? StoreID { get; set; }
        int? DepartmentID { get; set; }
        string Password { get; set; }
        int GroupID { get; }
        DateTime? DateOfBirth { get; set; }
        int ProfileID { get; set; }
        int Function { get; }
        int? ReportsToUserID { get; set; }
        int RoleID { get; set; }
        UserCustomUserField CustomUserFieldValues { get; set; }
    }
}
