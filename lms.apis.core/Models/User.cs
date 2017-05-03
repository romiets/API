using FluentValidation;
using System;
using System.Collections.Generic;

using lms.apis.core.Models.Interfaces;
using lms.apis.core.Entities;
using lms.apis.core.Helpers;

namespace lms.apis.core.Models
{
    public class User: IUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public int? StateID { get; set; }
        public string PostCode { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? UserMadeInactiveOnDate { get; set; }
        public int SupplierID { get { return 1; } }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get { return 1; } }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DateMadeInactive { get; set; }
        public int? DeactivatedByUserID { get; set; }
        public int TenantID { get; set; }
        public int? CompanyID { get; set; }
        public int? RegionID { get; set; }
        public int? StoreID { get; set; }
        public int? DepartmentID { get; set; }
        public string Password { get; set; }
        public int GroupID { get { return 0; } }
        public DateTime? DateOfBirth { get; set; }
        public int ProfileID { get; set; }
        public int Function { get { return 0; } }
        public int? ReportsToUserID { get; set; }
        public int RoleID { get; set; }
        public int? SourceApplicationID { get; set; }
        public UserCustomUserField CustomUserFieldValues { get; set; }
        public bool HasValidationError { get; set; }
        public IEnumerable<dynamic> ValidationErrors { get; set; }
    }

    public class UserViewModelValidator : AbstractValidator<User>
    {
        private readonly IDbContext dbContext;
        public UserViewModelValidator(IDbContext dbContext)
        {
            this.dbContext = dbContext;
            UserViewModelValidatorRules();
        }

        public void UserViewModelValidatorRules()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(u => u.UserName).Length(1, 50).WithMessage("Invalid Username");
            RuleFor(u => u.UserName).Must((user, error) => UserDoesNotExists(user.UserName, user.TenantID)).WithMessage("Username already exists");
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("FirstName cannot be empty");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("LastName cannot be empty");
            RuleFor(u => u.Email).Must((user, error) => IsValidEmail(user.Email)).WithMessage("Invalid email");
        }

        public bool UserDoesNotExists(string UserName, int TenantID)
        {
            bool  exist = dbContext.ValidateUser(UserName, TenantID)[0];
            return !exist;
        }

        public bool IsValidEmail(string email)
        {
            return Toolbox.IsValidEmail(email);
        }

    }
}