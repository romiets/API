using System;

namespace lms.apis.core.Models.Interfaces
{
    public interface ICompany
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Code { get; set; }
        string CompanyAddress { get; set; }
        string ContactName { get; set; }
        string ContactAddress { get; set; }
        string ContactPhone { get; set; }
        string Email { get; set; }
        string Suburb { get; set; }
        int CompanyStateId { get; set; }
        DateTime DateIn { get; set; }
        string FaxNumber { get; set; }
        Boolean IsActive { get; set; }
        string CompanyDescription { get; set; }
        string RegionDescr { get; set; }
        string LocationDescr { get; set; }
        string AreaDescr { get; set; }
        string Theme { get; set; }
        string SupportEmail { get; set; }
        int UserMonths { get; set; }
        bool NoTrainer { get; set; }
        int TenantId { get; set; }
        string TenantName { get; set; }
        string SubDomain { get; set; }
        bool isFlatTenant { get; set; }
        bool IsUserManagementEmailAddressMandatory { get; set; }
    }
}