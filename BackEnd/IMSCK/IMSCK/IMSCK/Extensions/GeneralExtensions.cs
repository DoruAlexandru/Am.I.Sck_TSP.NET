using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IMSCK.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetUserName(this HttpContext httpContext)
        {

            if (httpContext.User == null)
            {
                return string.Empty;
            }
            else
            {
                return httpContext.User.Claims.Single(x => x.Type == "Username").Value;
            }

        }
    }
}
