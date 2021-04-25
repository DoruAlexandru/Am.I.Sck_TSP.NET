using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMSCK.API
{
    [Route("Hi")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HiController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Hi";

        }
    }
}
