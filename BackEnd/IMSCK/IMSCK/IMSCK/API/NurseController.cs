using IMSCK.DAO;
using IMSCK.Model;
using IMSCK.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMSCK.API
{
    [Route("nurses")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NurseController : Controller
    {
        private readonly NurseService nurseService;

        public NurseController()
        {
            nurseService = new NurseService(new NurseDao());
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get([FromBody] CoordinatesDto credentials)
        {
            ServiceResponse<List<Dictionary<string, string>>> response = await nurseService.getNurses(credentials);
            if (response.Data.Count != 0)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

    }
}
