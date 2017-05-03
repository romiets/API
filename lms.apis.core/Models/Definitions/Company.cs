using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lms.apis.core.Models.Definitions
{
    [Table("Admin_company")]
    public class Company
    {
        [Key, Column(Order = 0)]
        public int companyID { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string contactAddress { get; set; }
        public string contactPhone { get; set; }
        public string email { get; set; }
        public DateTime dateIn { get; set; }
        public string address { get; set; }
        public string suburb { get; set; }
        [Key, Column(Order = 1)]
        public Nullable<int> state { get; set; }
        public string postCode { get; set; }
        public string faxNumber { get; set; }
        public string companyLogo { get; set; }
        public string bannerBG { get; set; }
        public string styleSheet { get; set; }
        public Nullable<bool> courseInBanner { get; set; }
        public Nullable<bool> multiLevel { get; set; }
        public string controlpanelBG { get; set; }
        public string WelcomeHTML { get; set; }
        public Nullable<bool> learningStatus { get; set; }
        public string CourseImageSpec { get; set; }
        public string ResetPasswordRule { get; set; }
        public Nullable<bool> DataMigrated { get; set; }
        public string descrStore { get; set; }
        public Nullable<int> daysForNew { get; set; }
        public string UserNameField { get; set; }
        public string UserNameFieldDescription { get; set; }
        public Nullable<bool> defaultCompany { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string Theme { get; set; }
        public string supportEmail { get; set; }
        public int defaultUserMonths { get; set; }
        public bool noTrainer { get; set; }
        public string code { get; set; }
        public Nullable<DateTime> Updated { get; set; }
        public Nullable<int> default_audienceID { get; set; }
        [Key, Column(Order = 2)]        
        public Nullable<int> tenantID { get; set; }
    }
}