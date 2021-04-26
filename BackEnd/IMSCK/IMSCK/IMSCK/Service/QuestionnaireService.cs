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

            int idQuestionnaire = await questionnaireDAO.addQuestionnaire(questionnaire.username, 50);
            if (idQuestionnaire == -1) {
                response.Message = "Could not add the questionnaire!";
                response.Success = false;
                return response;
            }

            bool resultQuestionnaireSymptoms = await questionnaireDAO.addQuestionnaireSymptoms(questionnaire, idQuestionnaire);

            Dictionary<string, string> data = new Dictionary<string, string>();

            if (resultQuestionnaireSymptoms==false)
            {
                //rollback insert in questionnaire
                //rollback insert in questionnaire
                if (await questionnaireDAO.rollbackAddQuestionnaire(idQuestionnaire)) {
                    response.Message = "Could not add the questionnaire, rolled back the inserted values!";
                    response.Success = false;
                    return response;
                }

                response.Message = "Could not add the questionnaire, rolled back unsuccesfully!";
                response.Success = false;
                return response;
            }

            data.Add("result", "add something here");

            //implement AI calculation based on responses
            //add details to response.Data

            response.Data = data;

            return response;
        }

    }
}
