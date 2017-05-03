using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

using lms.apis.core.Helpers;
using lms.apis.core.Models;
using lms.apis.core.Models.Interfaces;
using static lms.apis.core.Constants.StoredProcedureAttributes;

namespace lms.apis.core.Entities.Core
{
    public partial class ApiDbContext : DbContext, IDbContext
    {
        IValidatorFactory validatorFactory;
        IValidation validation;
        public ApiDbContext(
            IValidatorFactory validatorFactory,
            IValidation validation
        ) : base("name=LmsConnectionString")
        {
            this.validatorFactory = validatorFactory;
            this.validation = validation;

            validation.HasValidationError = false;
        }
        public virtual IValidation ValidateModel<T>(T model)
        {
            var errors = new List<dynamic>();
            var validator = validatorFactory.GetValidator<T>();
            var validationResults = validator.Validate(model);

            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    errors.Add(
                        new
                        {
                            FieldName = error.PropertyName,
                            ErrorMessage = error.ErrorMessage
                        });
                }

                validation.HasValidationError = true;
                validation.ValidationErrors = errors;
            }

            return validation;
        }

        public virtual User SaveUser(User user)
        {

            user.Password = CompanySettingsValueByKeyGet(CompanyDetailsSpAttribute.DefaultPassword, (int)user.CompanyID);

            SqlParameter[] spParameters =
                {
                        new SqlParameter { ParameterName = UserUpdateSpAttribute.ProcResult, SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output }
                        , ParameterValue(user.CompanyID, UserUpdateSpAttribute.CompanyId)
                        , ParameterValue(user.RegionID, UserUpdateSpAttribute.RegionId)
                        , ParameterValue(user.StoreID, UserUpdateSpAttribute.StoreId)
                        , ParameterValue(user.DepartmentID, UserUpdateSpAttribute.DepartmentID)
                        , ParameterValue(user.UserID, UserUpdateSpAttribute.UserId)
                        , ParameterValue(user.UserName, UserUpdateSpAttribute.Username)
                        , ParameterValue(user.FirstName, UserUpdateSpAttribute.Firstname)
                        , ParameterValue(user.LastName, UserUpdateSpAttribute.Lastname)
                        , ParameterValue(user.Password, UserUpdateSpAttribute.Password)
                        , ParameterValue(user.Email, UserUpdateSpAttribute.Email)
                        , ParameterValue(user.Address, UserUpdateSpAttribute.Address)
                        , ParameterValue(user.PostCode, UserUpdateSpAttribute.Postcode)
                        , ParameterValue(user.CountryCode, UserUpdateSpAttribute.CountryCode)
                        , ParameterValue(user.StateID, UserUpdateSpAttribute.StateId)
                        , ParameterValue(user.UserMadeInactiveOnDate, UserUpdateSpAttribute.DateOut)
                        , ParameterValue(user.PhoneNumber, UserUpdateSpAttribute.Phone)
                        , ParameterValue(user.Suburb, UserUpdateSpAttribute.Suburb)
                        , ParameterValue(user.SupplierID, UserUpdateSpAttribute.SupplierId)
                        , ParameterValue(user.GroupID, UserUpdateSpAttribute.GroupId)
                        , ParameterValue(user.DateOfBirth, UserUpdateSpAttribute.Dob)
                        , ParameterValue(user.IsActive, UserUpdateSpAttribute.IsActive)
                        , ParameterValue(user.ProfileID, UserUpdateSpAttribute.ProfileId)
                        , ParameterValue(user.Function, UserUpdateSpAttribute.Function)
                        , ParameterValue(user.CreatedByUserID, UserUpdateSpAttribute.CreatedByUserId)
                        , ParameterValue(user.TenantID, UserUpdateSpAttribute.TenantId)
                        , ParameterValue(user.ReportsToUserID, UserUpdateSpAttribute.ReportsToUserId)
                        , ParameterValue(user.RoleID, UserUpdateSpAttribute.RoleId)
                        , ParameterValue(ConvertKeyValueToString(user.CustomUserFieldValues), UserUpdateSpAttribute.CustomerUserFieldData)
                        , ParameterValue(user.CreatedDate, UserUpdateSpAttribute.CreatedDate)
                        , ParameterValue(user.DateMadeInactive, UserUpdateSpAttribute.DateInactive)
                        , ParameterValue(user.DeactivatedByUserID, UserUpdateSpAttribute.DeactivatedByUserId)
                        , ParameterValue(user.SourceApplicationID, UserUpdateSpAttribute.SourceApplicationID)
                };

            var sqlQuery = AppendParameters(UserUpdateSpAttribute.SqlQuery, spParameters);
            List<TransactionResult> procResultData = Database.SqlQuery<TransactionResult>(sqlQuery, spParameters).ToList();

            var userId = (int)procResultData[0].id;
            if (userId > 0)
            {
                SetUserPasswords(userId, Toolbox.getSHA256Hash(user.Password));
            }

            return user;
        }

        public virtual void SetUserPasswords(int userID, string encrypted)
        {
            SqlParameter[] spParameters = {
                new SqlParameter
                {
                    ParameterName = UserUpdateSpAttribute.UserId,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input, Value = userID
                },
                new SqlParameter
                {
                    ParameterName = UserUpdateSpAttribute.Encrypted,
                    SqlDbType = SqlDbType.VarChar,
                    Size =64,
                    Direction = ParameterDirection.Input,
                    Value = encrypted
                },
                new SqlParameter
                {
                    ParameterName = UserUpdateSpAttribute.IsDefaultPassword,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    Value = 1
                }
            };

            Database.ExecuteSqlCommand(UserUpdateSpAttribute.SqlSetDefaultPasswordQuery, spParameters);
        }

        public virtual IList<bool> ValidateUser(string UserName, int TenantID)
        {
            var UsernameParam =
                    new SqlParameter
                    {
                        ParameterName = ValidateUserSpAttribute.Username,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Input,
                        Value = UserName
                    };

            var TenantIdParam =
                new SqlParameter
                {
                    ParameterName = ValidateUserSpAttribute.TenantId,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    Value = TenantID
                };

            var procResultData = 
                Database
                    .SqlQuery<bool>(ValidateUserSpAttribute.SqlQuery, TenantIdParam, UsernameParam)
                    .ToList();

            return procResultData;
        }

        private string AppendParameters(string sql, SqlParameter[] spParameters)
        {

            var sqlParameter = string.Empty;

            for (int index = 0; index < spParameters.Length; index++)
            {
                if (index == 0)
                {
                    sql = sql.Replace("{0}", spParameters[index].ParameterName);
                }
                else
                {
                    sqlParameter += ", " + spParameters[index].ParameterName;
                }
            }
            return sql + sqlParameter.Substring(1);
        }

        private SqlParameter ParameterValue<T>(T value, string fieldName)
        {
            return value != null
                ? new SqlParameter(fieldName, value)
                : new SqlParameter(fieldName, DBNull.Value);
        }

        private static string ConvertKeyValueToString(UserCustomUserField items)
        {
            if (items == null)
                return string.Empty;

            string keyValueString = null;
            string valueSeparator = UserUpdateSpAttribute.ValueSeparator;
            string itemSeparator = UserUpdateSpAttribute.ItemSeparator;

            foreach (var item in items.CustomUserFieldData)
            {
                if (!string.IsNullOrEmpty(keyValueString))
                {
                    keyValueString += itemSeparator;
                }

                keyValueString += item.Key + valueSeparator + item.Value;
            }

            return keyValueString;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
