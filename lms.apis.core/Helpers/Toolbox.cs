using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

using lms.apis.core.Constants;

namespace lms.apis.core.Helpers
{
    public class Toolbox
    {
        public static T GetValue<T>(object value)
        {
            T result = default(T);
            if (value != null && value != DBNull.Value)
            {
                if (result is int)
                {
                    value = Convert.ToInt32(value);
                }
                else if (result is DateTime)
                {
                    value = Convert.ToDateTime(value);
                }
                else if (result is bool)
                {
                    value = Convert.ToBoolean(value);
                }
                else if (result is double)
                {
                    value = Convert.ToDouble(value);
                }

                result = (T)value;
            }

            return result;
        }

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, Common.EmailPattern, RegexOptions.IgnoreCase);
        }

        public static string getSHA256Hash(string input)
        {
            System.Security.Cryptography.SHA256Managed SH256Hasher = new System.Security.Cryptography.SHA256Managed();
            byte[] data = SH256Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString(Common.Sha256HashFormatString));
            }

            return sBuilder.ToString();
        }

    }

    public class HttpActionResult : IHttpActionResult
    {
        private readonly string _message;
        private readonly HttpStatusCode _statusCode;

        public HttpActionResult(HttpStatusCode statusCode, string message)
        {
            _statusCode = statusCode;
            _message = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(_statusCode)
            {
                Content = new StringContent(_message)
            };
            return Task.FromResult(response);
        }
    }
}