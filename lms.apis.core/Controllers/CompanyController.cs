using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

using lms.apis.core.Constants;
using lms.apis.core.Entities;
using lms.apis.core.Helpers;
using lms.apis.core.Models;
using lms.apis.core.Models.StoredProcedureReturnModel;
using lms.apis.core.Securities;
using lms.apis.core.Factories;

using static lms.apis.core.Constants.StoredProcedureAttributes;

namespace lms.apis.core.Controllers
{
    [IdentityBasicAuthentication, Authorize]
    [RoutePrefix(WebApiRouteAttributes.CompanyInfoRootApiRoute)]    
    public class CompanyController : BaseController
    {
        private readonly IDbContext dbContext;
        private readonly IGenericResponseObjectFactory response;

        public CompanyController(
            IDbContext dbContext,
            IGenericResponseObjectFactory response
        ) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.response = response;
        }

        [Route(WebApiRouteAttributes.CompanyInfoGetApiRoute)]
        public ResponseObject<Company> GetCompanyDetails(int companyId)
        {
            return response
                        .Make(() => dbContext
                            .GetCompanyDetails(companyId)
                            .ToCompanyViewModel());
        }

        [Route(WebApiRouteAttributes.CompanyInfoRegionGetApiRoute)]
        public ResponseObject<IEnumerable<Region>> GetRegions(int companyId)
        {
            return response.Make(() => dbContext.GetRegions(companyId));
        }

        [Route(WebApiRouteAttributes.CompanyInfoOfficeGetApiRoute)]
        public ResponseObject<IEnumerable<Office>> GetOffices(int companyId, int regionId)
        {
            return response.Make(() => dbContext.GetOffices(companyId, regionId));
        }

        [Route(WebApiRouteAttributes.CompanyInfoDepartmentGetApiRoute)]
        public ResponseObject<IEnumerable<Department>> GetDepartments(int companyId, int regionId, int officeId)
        {
            return response.Make(() => dbContext.GetDepartments(companyId, regionId, officeId));
        }

        [Route(WebApiRouteAttributes.CompanyInfoStructureGetApiRoute)]
        public ResponseObject<IEnumerable<CompanyStructure>> GetCompanyStructure(int companyId)
        {
            return response.Make(() => dbContext.GetCompanyStructure(companyId));
        }

        [Route(WebApiRouteAttributes.CompanyInfoRolesGetApiRoute)]
        public ResponseObject<IEnumerable<Role>> GetRoles(int companyId)
        {
            return response.Make(() => dbContext.GetRoles(companyId));
        }

        [Route(WebApiRouteAttributes.CompanyInfoCufGetApiRoute)]
        public ResponseObject<List<CompanyCustomUserField>> GetCompanyCustomUserField(int companyId)
        {
            return response
                        .Make(() => dbContext
                            .GetCustomUserFields(companyId)
                            .ToCompanyCustomUserFieldViewModel(this.dbContext));
        }

        [Route(WebApiRouteAttributes.CompanyInfoSelfRegistrationAvailabilityApiRoute)]
        public IHttpActionResult GetSelfRegistrationAvailability(int companyId)
        {
            var success = dbContext.GetSelfRegistrationAvailability(companyId);
            if (success)
            {
                return Ok();

            }

            return new HttpActionResult(HttpStatusCode.NotFound, Errors.Values.Unknown);
        }
    }

    public static class CompanyPresentationsExtension
    {
        public static Company ToCompanyViewModel(this SpCompanyDetailReturnModel rawCompanyDetails)
        {
            try
            {
                var company = rawCompanyDetails;
                return
                    new Company()
                    {
                        Id = Toolbox.GetValue<int>(company.companyID),
                        Name = Toolbox.GetValue<string>(company.companyName),
                        Description = Toolbox.GetValue<string>(company.contactName),
                        Code = Toolbox.GetValue<string>(company.code),
                        CompanyAddress = Toolbox.GetValue<string>(company.address),
                        ContactName = Toolbox.GetValue<string>(company.contactName),
                        ContactAddress = Toolbox.GetValue<string>(company.contactAddress),
                        ContactPhone = Toolbox.GetValue<string>(company.contactPhone),
                        Email = Toolbox.GetValue<string>(company.email),
                        Suburb = Toolbox.GetValue<string>(company.suburb),
                        CompanyStateId = Toolbox.GetValue<int>(company.state),
                        DateIn = Toolbox.GetValue<DateTime>(company.dateIn),
                        FaxNumber = Toolbox.GetValue<string>(company.faxNumber),
                        IsActive = Toolbox.GetValue<bool>(company.isActive),
                        Theme = Toolbox.GetValue<string>(company.Theme),
                        SupportEmail = Toolbox.GetValue<string>(company.supportEmail),
                        UserMonths = Toolbox.GetValue<int>(company.defaultUserMonths),
                        NoTrainer = Toolbox.GetValue<bool>(company.noTrainer),
                        TenantId = Toolbox.GetValue<int>(company.tenantID),
                        SubDomain = Toolbox.GetValue<string>(company.Domain),
                        TenantName = Toolbox.GetValue<string>(company.TenantName),
                        isFlatTenant = Toolbox.GetValue<bool>(company.isFlatTenant),
                        IsUserManagementEmailAddressMandatory = Toolbox.GetValue<bool>(company.IsUserManagementEmailAddressMandatory),
                        CompanyDescription = CompanyDetailsSpAttribute.CompanyDescriptionDefaultValue,
                        RegionDescr = CompanyDetailsSpAttribute.RegionDescrDefaultValue,
                        LocationDescr = CompanyDetailsSpAttribute.LocationDescrDefaultValue,
                        AreaDescr = CompanyDetailsSpAttribute.AreaDescrDefaultValue
                    };
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
  
        }
        
        public static List<CompanyCustomUserField> ToCompanyCustomUserFieldViewModel(this List<SpCustomUserFieldReturnModel> rawCompanyCustomUserField, IDbContext dbContex)
        {
            try
            {               
                List<SpCustomUserFieldReturnModel> cufRaw = rawCompanyCustomUserField;
                List<CompanyCustomUserField> cufList = new List<CompanyCustomUserField>();
                CompanyCustomUserField cufData;
                List<SpCustomUserFieldOptionListReturnModel> optionList;                

                foreach (SpCustomUserFieldReturnModel cuf in cufRaw)
                {
                    cufData = new CompanyCustomUserField()
                    {
                        CustomUserFieldID = cuf.CustomUserFieldID,
                        Value = cuf.Value,
                        TenantName = cuf.TenantName,
                        CompanyName = cuf.CompanyName,
                        TenantID = cuf.TenantID,
                        AllCompanies = cuf.AllCompanies,
                        OwnerID = cuf.OwnerID,
                        OwnerType = cuf.OwnerType,
                        IsActive = cuf.IsActive,
                        FieldName = cuf.FieldName,
                        FieldType = cuf.FieldType,
                        IsMandatory = cuf.IsMandatory,
                        CreatedByUserID = cuf.CreatedByUserID,
                        CreatedDate = cuf.CreatedDate
                    };

                    cufData.OptionList = new List<CompanyCustomUserFieldOptionList>();
                    if (cuf.FieldType == (int)CustomUserFieldType.List)
                    {
                        optionList = dbContex.GetCustomUserFieldOptionList(cuf.CustomUserFieldID);                        

                        foreach (SpCustomUserFieldOptionListReturnModel option in optionList)
                        {
                            cufData.OptionList.Add(new CompanyCustomUserFieldOptionList()
                            {
                                CustomUserFieldOptionID = option.CustomUserFieldOptionID,
                                CustomUserFieldID = option.CustomUserFieldID,
                                Text = option.Option,
                                IsActive = option.IsActive,
                                CreatedByUserID = option.CreatedByUserID,
                                CreatedDate = option.CreatedDate
                            });
                        }                        
                    }

                    cufList.Add(cufData);
                }

                return cufList;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

        }
    }
}
