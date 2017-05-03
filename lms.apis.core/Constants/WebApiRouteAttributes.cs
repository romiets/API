namespace lms.apis.core.Constants
{
    public static class WebApiRouteAttributes
    {
        //--Start: Api Routes
        public const string DefaultControllerRoute = "";

        //--Registration Api Routes
        public const string SelfRegistrationRootApiRoute = "api/registration";
        public const string SelfRegistrationSaveApiRoute = "save";
        public const string SelfRegistrationValidateUserApiRoute = "validate/user";

        //--Company Api Routes
        public const string CompanyInfoRootApiRoute = "api/company";
        public const string CompanyInfoGetApiRoute = "{companyId:int}";
        public const string CompanyInfoCufGetApiRoute = "{companyId:int}/cufs";
        public const string CompanyInfoRegionGetApiRoute = "{companyId:int}/regions";
        public const string CompanyInfoOfficeGetApiRoute = "{companyId:int}/region/{regionId:int}/offices";
        public const string CompanyInfoDepartmentGetApiRoute = "{companyId:int}/region/{regionId:int}/office/{officeId:int}/departments";
        public const string CompanyInfoStructureGetApiRoute = "{companyId:int}/structure";
        public const string CompanyInfoRolesGetApiRoute = "{companyId:int}/roles";
        public const string CompanyInfoSelfRegistrationAvailabilityApiRoute = "{companyId:int}/selfregistration/available";

        //--State Api Routes
        public const string StateInfoRootApiRoute = "api/state";
        public const string StateInfoGetApiRoute = "list";

        //--Api Ping
        public const string ApiHandshakeCheckRoute = "api/handshake/check";

        //--End: Api Routes

    }
}