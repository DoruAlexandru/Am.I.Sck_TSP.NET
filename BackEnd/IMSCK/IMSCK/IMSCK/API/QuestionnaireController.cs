using IMSCK.DAO;
using IMSCK.Model;
using IMSCK.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSCK.API
{
    [Route("questionnaire/")]
    [ApiController]
    public class QuestionnaireController : Controller
    {
        private QuestionnaireService questionnaireService;

        public QuestionnaireController()
        {
            questionnaireService = new QuestionnaireService();
        }


        [HttpPost]
        [Route("addQuestionnaire/")]
        public async Task<IActionResult> Post([FromBody] QuestionnaireDTO questionnaire)
        {
            
            ServiceResponse<Dictionary<string, string>> response = await questionnaireService.addQuestionnaire(questionnaire);

            if (response.Success == true)
            {
                return Ok(response);
            }
            return BadRequest(response);
            
        }
    }
}
