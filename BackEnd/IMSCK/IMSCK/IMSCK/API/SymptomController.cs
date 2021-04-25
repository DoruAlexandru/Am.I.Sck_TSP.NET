using IMSCK.DAO;
using IMSCK.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSCK.API
{
    [Route("symptom")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SymptomController : Controller
    {
        private SymptomService symptomService;

        public SymptomController()
        {
            symptomService = new SymptomService();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResponse < List < Dictionary<string, string>>> response = await symptomService.getSymptoms();
            System.Console.WriteLine(response.Data);
            if (response.Data.Count != 0)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }
    }
}
