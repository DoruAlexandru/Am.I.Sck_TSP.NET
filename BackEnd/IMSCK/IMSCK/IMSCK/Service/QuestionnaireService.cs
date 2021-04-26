using IMSCK.DAO;
using IMSCK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSCK.Service
{
    public class QuestionnaireService
    {
        private QuestionnaireDAO questionnaireDAO;

        public QuestionnaireService()
        {
            this.questionnaireDAO = new QuestionnaireDAO();
        }

        public async Task<ServiceResponse<Dictionary<string, string>>> addQuestionnaire(QuestionnaireDTO questionnaire)
        {
            ServiceResponse<Dictionary<string, string>> response = new ServiceResponse<Dictionary<string, string>>();

            bool result = await questionnaireDAO.addQuestionnaire(questionnaire);

            Dictionary<string, string> data = new Dictionary<string, string>();

            if (result == false)
            {
                response.Message = "Could not add the questionnaire!";
                response.Success = false;
                return response;
            }

            data.Add("result", result.ToString());

            //implement AI calculation based on responses
            //add details to response.Data

            response.Data = data;

            return response;
        }

    }
}
