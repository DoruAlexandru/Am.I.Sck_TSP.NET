using IMSCK.DAO;
using IMSCK.Model;
using IMSCK.Service;
using IMSCK.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IMSCK.API
{
    [Route("questionnaire/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class QuestionnaireController : Controller
    {
        private readonly QuestionnaireService questionnaireService;

        public QuestionnaireController()
        {
            questionnaireService = new QuestionnaireService(new QuestionnaireDao());
        }


        [HttpPost]
        [Route("addQuestionnaire")]
        public async Task<IActionResult> Post([FromBody] QuestionnaireDto questionnaire)
        {
            
            ServiceResponse<Dictionary<string, string>> response = await questionnaireService.addQuestionnaire(questionnaire);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
            
        }


        [HttpGet]
        [Route("getAllQuestionnaires")]
        public async Task<IActionResult> Get()
        {
            string username = HttpContext.GetUserName();

            ServiceResponse<List<Dictionary<string, string>>> response = await questionnaireService.getQuestionnaires(username);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpGet]
        [Route("symptoms/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            string username = HttpContext.GetUserName();

            ServiceResponse<List<Dictionary<string, string>>> response = await questionnaireService.getQuestionnaireSymptoms(username, id);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }
    }
}
