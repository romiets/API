using System.Collections.Generic;
using System.Data.Entity;

using lms.apis.core.Models;
using lms.apis.core.Models.Interfaces;
using lms.apis.core.Models.StoredProcedureReturnModel;

using dbo = lms.apis.core.Models.Definitions;

namespace lms.apis.core.Entities
{
    public interface IDbContext
    {
        DbSet<dbo.Role> Role { get; set; }
        DbSet<dbo.Company> Company { get; set; }
        DbSet<dbo.CompanyStructure> CompanyStructure { get; set; }
        DbSet<dbo.SettingsText> SettingsText { get; set; }
        DbSet<dbo.State> State { get; set; }
        IEnumerable<Models.Role> GetRoles(int companyId);
        IEnumerable<Models.CompanyStructure> GetCompanyStructure(int companyId);
        IEnumerable<Department> GetDepartments(int companyId, int regionId, int officeId);
        IEnumerable<Office> GetOffices(int companyId, int regionId);
        IEnumerable<Region> GetRegions(int companyId);
        IEnumerable<State> GetStates();
        List<SpCustomUserFieldReturnModel> GetCustomUserFields(int companyId);
        List<SpCustomUserFieldOptionListReturnModel> GetCustomUserFieldOptionList(int customUserFieldId);
        bool GetSelfRegistrationAvailability(int companyId);
        IValidation ValidateModel<T>(T model);
        SpCompanyDetailReturnModel GetCompanyDetails(int companyId);        
        IList<bool> ValidateUser(string UserName, int TenantID);
        User SaveUser(User user);
        void SetUserPasswords(int userID, string encrypted);
    }
}
