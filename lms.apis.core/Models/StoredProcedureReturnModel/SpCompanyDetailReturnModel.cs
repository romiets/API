using System;

namespace lms.apis.core.Models.StoredProcedureReturnModel
{
    public class SpCompanyDetailReturnModel
    {
        public int companyID { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string contactAddress { get; set; }
        public string contactPhone { get; set; }
        public string email { get; set; }
        public DateTime dateIn { get; set; }
        public string address { get; set; }
        public string suburb { get; set; }
        public string state { get; set; }
        public string postCode { get; set; }
        public string faxNumber { get; set; }
        public string companyLogo { get; set; }
        public string bannerBG { get; set; }
        public string styleSheet { get; set; }
        public bool? courseInBanner { get; set; }
        public bool? multiLevel { get; set; }
        public string controlPanelBG { get; set; }
        public string WelcomeHTML { get; set; }
        public bool? learningStatus { get; set; }
        public string CourseImageSpec { get; set; }
        public string ResetPasswordRule { get; set; }
        public bool? DateMigrated { get; set; }
        public string descStore { get; set; }
        public int? daysForNew { get; set; }
        public string UserNameField { get; set; }
        public string UserNameFieldDescription { get; set; }
        public bool? defaultCompany { get; set; }
        public bool? isActive { get; set; }
        public string Theme { get; set; }
        public string supportEmail { get; set; }
        public int defaultUserMonths { get; set; }
        public bool? noTrainer { get; set; }
        public string code { get; set; }
        public DateTime? Updated { get; set; }
        public int? default_audienceID { get; set; }
        public int? tenantID { get; set; }
        public string Domain { get; set; }
        public string TenantName { get; set; }
        public bool isFlatTenant { get; set; }
        public bool IsUserManagementEmailAddressMandatory { get; set; }
    }
}