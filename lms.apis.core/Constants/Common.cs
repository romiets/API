using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lms.apis.core.Constants
{
    public static class Common
    {
        public const string Truthy = "TRUE";
        public const string Falsy = "FALSE";

        public const string TenantOwnerType = "TEN";
        public const string FlatTenantKey = "FlatOrganisationalStructure";
        public const string UserManagementEmailMandatory = "UserManagementEmailAddressMandatory";

        public const string Sha256HashFormatString = "x2";
        public const string AlphanumericRegexExpression = "[^a-zA-Z0-9-]";
        public const string MediaTypeWithQualityHeaderJsonValue = "application/json";
        public const string AuthenticationBasic = "Basic";

        public const string
            EmailPattern =
                @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

        public enum SourceApplication
        {
            Admin = 1,
            Import = 2,
            SelfRegistration = 3,
            API = 4
        }
    }
}