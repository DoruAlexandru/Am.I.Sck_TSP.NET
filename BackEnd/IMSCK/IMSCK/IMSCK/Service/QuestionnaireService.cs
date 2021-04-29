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
        private readonly IQuestionnaireDao questionnaireDAO;

        public QuestionnaireService(IQuestionnaireDao questionnaireDAO)
        {
            this.questionnaireDAO = questionnaireDAO;
        }

        public async Task<ServiceResponse<Dictionary<string, string>>> addQuestionnaire(QuestionnaireDto questionnaire)
        {
            ServiceResponse<Dictionary<string, string>> response = new ServiceResponse<Dictionary<string, string>>();

            if (questionnaire.symptoms.Count == 0)
            {
                response.Message = "Symptoms are missing";
                response.Success = false;
                return response;
            }

            int idQuestionnaire = await questionnaireDAO.addQuestionnaire(questionnaire.username, 50);

            if (idQuestionnaire == -1)
            {
                response.Message = "Could not add the questionnaire!";
                response.Success = false;
                return response;
            }

            bool resultQuestionnaireSymptoms = await questionnaireDAO.addQuestionnaireSymptoms(questionnaire, idQuestionnaire);

            Dictionary<string, string> data = new Dictionary<string, string>();

            if (!resultQuestionnaireSymptoms)
            {
                //rollback insert in questionnaire
                //rollback insert in questionnaire
                if (await questionnaireDAO.rollbackAddQuestionnaire(idQuestionnaire))
                {
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

        public async Task<ServiceResponse<List<Dictionary<string, string>>>> getQuestionnaires(string username)
        {
            List<Dictionary<string, string>> questionnaires = await questionnaireDAO.getQuestionnaires(username);

            ServiceResponse<List<Dictionary<string, string>>> response = new ServiceResponse<List<Dictionary<string, string>>>();

            if (questionnaires.Count != 0)
            {
                response.Data = questionnaires;
                response.Success = true;
                response.Message = "Questionnaires retrieved succesfully!";

                return response;
            }

            response.Success = false;
            response.Message = "No questionnaire found";

            return response;

        }

        public async Task<ServiceResponse<List<Dictionary<string, string>>>> getQuestionnaireSymptoms(string username, int id)
        {
            List<Dictionary<string, string>> symptoms = await questionnaireDAO.getQuestionnaireSymptoms(username, id);

            ServiceResponse<List<Dictionary<string, string>>> response = new ServiceResponse<List<Dictionary<string, string>>>();

            if (symptoms.Count != 0)
            {
                response.Data = symptoms;
                response.Success = true;
                response.Message = "Questionnaire symptoms retrieved succesfully!";

                return response;
            }

            response.Success = false;
            response.Message = "No symptom found";

            return response;

        }

    }
}
