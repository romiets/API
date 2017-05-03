namespace lms.apis.core.Constants
{
    public class StoredProcedureAttributes
    {
        public static class UserUpdateSpAttribute
        {
            public const string Name = "LMS_UserUpdate_set";
            public const string SqlQuery = "EXEC [dbo].[LMS_UserUpdate_set]";
            public const string SqlSetDefaultPasswordQuery = "EXEC [dbo].[stp_UserPassword_set] @userID, @encrypted, @isDefaultPassword";
            public const string ValueSeparator = "@@";
            public const string ItemSeparator = "||";

            public const string CompanyId  = "@companyID";
            public const string RegionId = "@regionID";
            public const string StoreId  = "@storeID";
            public const string DepartmentID = "@departmentID";
            public const string UserId = "@userID";
            public const string Username = "@userName";
            public const string Firstname = "@firstName";
            public const string Lastname = "@lastName";
            public const string Password = "@password";
            public const string Email = "@email";
            public const string Address = "@address";
            public const string Postcode = "@postCode";
            public const string CountryCode = "@countryCode";
            public const string StateId = "@stateID";
            public const string DateOut = "@dateOut";
            public const string Phone = "@phone";
            public const string Suburb = "@suburb";
            public const string SupplierId = "@supplierID";
            public const string GroupId = "@groupID";
            public const string Dob = "@DOB";
            public const string IsActive = "@isActive";
            public const string ProfileId = "@profileID";
            public const string Function = "@function";
            public const string CreatedByUserId = "@createdByUserID";
            public const string TenantId = "@tenantID";
            public const string ReportsToUserId = "@reportsToUserID";
            public const string RoleId = "@roleID";
            public const string CustomerUserFieldData = "@customUserFieldData";
            public const string CreatedDate = "@createdDate";
            public const string DateInactive = "@dateInactive";
            public const string DeactivatedByUserId = "@deactivatedByUserID";
            public const string Encrypted = "@encrypted";
            public const string IsDefaultPassword = "@isDefaultPassword";
            public const string SourceApplicationID = "@SourceApplicationID";
            public const string ProcResult = "@procResult";
        }

        public static class CompanyDetailsSpAttribute
        {
            public const string Name = "LMS_UserUpdate_set";
            public const string SqlQuery = "EXEC [dbo].[LMS_CompanyDetails_get] @CompanyID";
            public const string KeySettingsSqlQuery = "EXEC [dbo].[stp_Settings_Value_GetByKey_ForCompany] @key, @companyID";
            public const string CompanyId = "@companyID";
            public const string RegionId = "@regionID";
            public const string OfficeId = "@storeID";
            public const string DepartmentId = "@DepartmentId";
            public const string SettingsKey = "@key";

            public const string CompanyDescriptionDefaultValue = "Company";
            public const string RegionDescrDefaultValue = "Region";
            public const string LocationDescrDefaultValue = "Location";
            public const string AreaDescrDefaultValue = "Area";

            public const string DefaultPassword = "DefaultPassword";
            public const string IsSelfRegEnabled = "IsSelfRegEnabled";
        }

        public static class ValidateUserSpAttribute
        {
            public const string Name = "stp_UserNameExists";
            public const string SqlQuery = "EXEC [dbo].[stp_UserNameExists] @tenantID, @userName";

            public const string Username = "@userName";
            public const string TenantId = "@tenantID";
        }

        public static class CustomUserFieldSpAttribute
        {
            public const string Name = "stp_CustomUserFieldListForUser_get";
            public const string SqlQuery = "EXEC [dbo].[stp_CustomUserFieldListForUser_get] @userID, @companyID, @showInactiveFields";

            public const string UserId = "@userID";
            public const string CompanyID = "@companyID";
            public const string ShowInactiveFields = "@showInactiveFields";
        }

        public static class CustomUserFieldOptionListSpAttribute
        {
            public const string Name = "stp_CustomUserFieldOptionList_get";
            public const string SqlQuery = "EXEC [dbo].[stp_CustomUserFieldOptionList_get] @customUserFieldID, @showInactiveFields, @userID";

            public const string CustomUserFieldId = "@customUserFieldID";
            public const string ShowInactiveFields = "@showInactiveFields";
            public const string UserId = "@userID";
        }

        public enum CustomUserFieldType
        {
            Text = 1,
            YesNo = 2,
            Check = 3,
            List = 4,
            Date = 5
        };
    }
}