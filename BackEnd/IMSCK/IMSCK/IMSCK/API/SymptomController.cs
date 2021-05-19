using IMSCK.DAO;
using IMSCK.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMSCK.API
{
    [Route("symptom")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SymptomController : Controller
    {
        private readonly SymptomService symptomService;

        public SymptomController()
        {
            symptomService = new SymptomService(new SymptomsDao());
        }

        [HttpGet]
        [Route("getAllSymptoms")]
        public async Task<IActionResult> Get()
        {
            ServiceResponse < List < Dictionary<string, string>>> response = await symptomService.getSymptoms();
            if (response.Data.Count != 0)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

    }
}
