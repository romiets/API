using System;

using lms.apis.core.Models.Interfaces;

namespace lms.apis.core.Models
{
    public class Company : ICompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string CompanyAddress { get; set; }
        public string ContactName { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public string Suburb { get; set; }
        public int CompanyStateId { get; set; }
        public DateTime DateIn { get; set; }
        public string FaxNumber { get; set; }
        public bool IsActive { get; set; }
        public string CompanyDescription { get; set; }
        public string RegionDescr { get; set; }
        public string LocationDescr { get; set; }
        public string AreaDescr { get; set; }
        public string Theme { get; set; }
        public string SupportEmail { get; set; }
        public int UserMonths { get; set; }
        public bool NoTrainer { get; set; }
        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string SubDomain { get; set; }
        public bool isFlatTenant { get; set; }
        public bool IsUserManagementEmailAddressMandatory { get; set; }
    }
}