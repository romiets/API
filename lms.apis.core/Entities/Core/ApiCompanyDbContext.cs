using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

using lms.apis.core.Constants;
using lms.apis.core.Models;
using lms.apis.core.Models.StoredProcedureReturnModel;

using static lms.apis.core.Constants.StoredProcedureAttributes;
using dbo = lms.apis.core.Models.Definitions;

namespace lms.apis.core.Entities.Core
{
    public partial class ApiDbContext : DbContext, IDbContext
    {
        public virtual DbSet<dbo.Role> Role { get; set; }
        public virtual DbSet<dbo.Company> Company { get; set; }
        public virtual DbSet<dbo.CompanyStructure> CompanyStructure { get; set; }
        public virtual DbSet<dbo.SettingsText> SettingsText { get; set; }
        public virtual DbSet<dbo.State> State { get; set; }

        public virtual IEnumerable<Role> GetRoles(int companyId)
        {
            int tenentID;
            int.TryParse(this.Company.Where(e => e.companyID == companyId).Select(e => e.tenantID).FirstOrDefault().ToString(), out tenentID);

            IEnumerable<Role> result = this.Role
                .Where(e => e.OwnerID == tenentID)
                .Select(e => new Role()
                    {
                        RoleID = e.RoleID,
                        RoleName = e.Name
                    }).AsEnumerable();

            return result;
        }

        public virtual SpCompanyDetailReturnModel GetCompanyDetails(int companyId)
        {
            SqlParameter companyIdParam = 
                    new SqlParameter
                    {
                        ParameterName = CompanyDetailsSpAttribute.CompanyId,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input,
                        Value = companyId
                    };

            SpCompanyDetailReturnModel procResultData = 
                Database
                    .SqlQuery<SpCompanyDetailReturnModel>(CompanyDetailsSpAttribute.SqlQuery, companyIdParam)
                    .FirstOrDefault();

            GetSettings(procResultData);

            List<SpCustomUserFieldReturnModel> CustomUserFields = GetCustomUserFields(companyId);

            return procResultData;
        }

        public virtual List<SpCustomUserFieldReturnModel> GetCustomUserFields(int companyId)
        {
            SqlParameter[] spParameters = {
                new SqlParameter
                {
                    ParameterName = CustomUserFieldSpAttribute.UserId,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input, Value = 0
                },
                new SqlParameter
                {
                    ParameterName = CustomUserFieldSpAttribute.CompanyID,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input, Value = companyId
                },
                new SqlParameter
                {
                    ParameterName = CustomUserFieldSpAttribute.ShowInactiveFields,
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Input, Value = 0
                }
            };

            List<SpCustomUserFieldReturnModel> procResultData = 
                Database
                    .SqlQuery<SpCustomUserFieldReturnModel>(CustomUserFieldSpAttribute.SqlQuery, spParameters)
                    .ToList();

            return procResultData;
        }

        public virtual List<SpCustomUserFieldOptionListReturnModel> GetCustomUserFieldOptionList(int customUserFieldId)
        {
            SqlParameter[] spParameters = {
                new SqlParameter
                {
                    ParameterName = CustomUserFieldOptionListSpAttribute.CustomUserFieldId,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    Value = customUserFieldId
                },
                new SqlParameter
                {
                    ParameterName = CustomUserFieldOptionListSpAttribute.ShowInactiveFields,
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Input,
                    Value = 0
                },
                new SqlParameter
                {
                    ParameterName = CustomUserFieldOptionListSpAttribute.UserId,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    Value = 0
                }
            };

            List<SpCustomUserFieldOptionListReturnModel> procResultData = 
                Database
                    .SqlQuery<SpCustomUserFieldOptionListReturnModel>(CustomUserFieldOptionListSpAttribute.SqlQuery, spParameters)
                    .ToList();

            return procResultData;
        }

        public virtual string CompanySettingsValueByKeyGet(string key, int companyId)
        {
            SqlParameter[] spParameters = {
                new SqlParameter
                {
                    ParameterName = CompanyDetailsSpAttribute.SettingsKey,
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Value = key
                },
                new SqlParameter
                {
                    ParameterName = CompanyDetailsSpAttribute.CompanyId,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    Value = companyId
                }
            };

            string procResultData = 
                Database
                    .SqlQuery<string>(CompanyDetailsSpAttribute.KeySettingsSqlQuery, spParameters)
                    .ToList()
                    .FirstOrDefault();

            return procResultData;
        }

        public virtual IEnumerable<Region> GetRegions(int companyId)
        {
            IEnumerable<Region> result = this.CompanyStructure
                .Where(p => p.companyID == companyId)
                .Select(p => new Region()
                    {
                        RegionId = p.regionID,
                        RegionName = p.regionName
                    })
                .GroupBy(p => p.RegionId)
                .Select(p => p.FirstOrDefault()).ToList();

            return result;
        }

        public virtual bool GetSelfRegistrationAvailability(int companyId)
        {
            string selfRegAvailabilitySetting = CompanySettingsValueByKeyGet(CompanyDetailsSpAttribute.IsSelfRegEnabled, companyId);
            bool isSelfRegEnabled = (selfRegAvailabilitySetting == null ? false : bool.Parse(selfRegAvailabilitySetting));

            return isSelfRegEnabled;
        }

        public virtual IEnumerable<Office> GetOffices(int companyId, int regionId)
        {
            IEnumerable<Office> result = this.CompanyStructure
                .Where(c => c.companyID == companyId && (regionId == 0) ? true : c.regionID == regionId)
                .Select(p => new Office()
                    {
                        OfficeId = p.storeID,
                        OfficeName = p.storeName
                    })
                .GroupBy(p => p.OfficeId)
                .Select(p => p.FirstOrDefault())
                .ToList();

            return result;
        }

        public virtual IEnumerable<Department> GetDepartments(int companyId, int regionId, int officeId)
        {
            IEnumerable<Department> result = this.CompanyStructure
                .Where(c => c.companyID == companyId && (regionId == 0 && officeId == 0) ? true : (c.regionID == regionId && c.storeID == officeId))
                .Select(p => new Department()
                    {
                        DepartmentId = p.departmentID,
                        DepartmentName = p.departmentName
                    })
                .GroupBy(p => p.DepartmentId)
                .Select(p => p.FirstOrDefault())
                .ToList();

            return result;
        }

        public virtual IEnumerable<CompanyStructure> GetCompanyStructure(int companyId)
        {
            IEnumerable<CompanyStructure> result = 
                CompanyStructure
                    .Where(c => c.companyID == companyId)
                    .Select(c => new CompanyStructure()
                        {
                            CompanyId = c.companyID,
                            CompanyName = c.companyName,
                            RegionId = c.regionID,
                            RegionName = c.regionName,
                            OfficeId = c.storeID,
                            OfficeName = c.storeName,
                            DepartmentId = c.departmentID,
                            DepartmentName = c.departmentName,
                            TenantId = c.TenantID,
                            TenantName = c.TenantName
                        })
                    .ToList();

            return result;
        }

        public virtual IEnumerable<State> GetStates()
        {
            var result = 
                State
                    .Where(s => s.stateID >= 0)
                    .Select(s => new State
                        {
                            StateID = s.stateID,
                            StateName = s.stateName
                        })
                    .ToList();

            return result;
        }

        private void GetSettings(SpCompanyDetailReturnModel company)
        {
            var result = (from s in this.SettingsText
                          join c in this.Company on s.OwnerID equals c.tenantID
                          where c.companyID == company.companyID
                             && s.OwnerType == Common.TenantOwnerType
                             && (s.key == Common.FlatTenantKey || s.key == Common.UserManagementEmailMandatory)
                          select (s)).ToList();

            if (result != null && result.Count() > 0)
            {
                company.isFlatTenant = result.Where(x => x.key == Common.FlatTenantKey).Select(y => y.value).FirstOrDefault().ToUpper() == Common.Truthy;
                company.IsUserManagementEmailAddressMandatory = result.Where(x => x.key == Common.UserManagementEmailMandatory).Select(y => y.value).FirstOrDefault().ToUpper() == Common.Truthy;
            }
            
        }
    }
}