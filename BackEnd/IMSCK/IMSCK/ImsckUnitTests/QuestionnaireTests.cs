using IMSCK.DAO;
using IMSCK.Model;
using IMSCK.Service;
using System.Collections.Generic;
using Xunit;

namespace ImsckUnitTests
{
    public class QuestionnaireTests
    {

        [Fact]
        public async void GetAllQuestionnaires()
        {
            QuestionnaireService questionnaireService = new QuestionnaireService(new QuestionnaireDao());

            string username = "Tudor";

            ServiceResponse<List<Dictionary<string, string>>> response = await questionnaireService.getQuestionnaires(username);

            bool expected = true;
            bool actual = false;

            if (response.Success)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }


        [Fact]
        public async void GetQuestionnaireSymptoms()
        {
            QuestionnaireService questionnaireService = new QuestionnaireService(new QuestionnaireDao());

            string username = "Gigel";
            int questionnaireId = 1;

            ServiceResponse<List<Dictionary<string, string>>> response = await questionnaireService.getQuestionnaireSymptoms(username, questionnaireId);

            bool expected = true;
            bool actual = false;

            if (response.Success)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void GetQuestionnaireSymptomsInvalidId()
        {
            QuestionnaireService questionnaireService = new QuestionnaireService(new QuestionnaireDao());

            string username = "Tudor";
            int questionnaireId = 99;// invalid Questionnaire Id

            ServiceResponse<List<Dictionary<string, string>>> response = await questionnaireService.getQuestionnaireSymptoms(username, questionnaireId);

            bool expected = false;
            bool actual = false;

            if (response.Success)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void AddQuestionnaireSuccess()
        {
            QuestionnaireService questionnaireService = new QuestionnaireService(new QuestionnaireDao());
            QuestionnaireDto questionnaire = new();

            questionnaire.username = "Tudor";
            questionnaire.symptoms = new Dictionary<string, string>();
            questionnaire.symptoms.Add("anxiety", "2");
            questionnaire.symptoms.Add("confusion", "3");

            ServiceResponse<Dictionary<string, string>> response = await questionnaireService.addQuestionnaire(questionnaire);

            bool expected = true;
            bool actual = false;

            if (response.Success)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void AddQuestionnaireEmptySymptoms()
        {
            QuestionnaireService questionnaireService = new QuestionnaireService(new QuestionnaireDao());
            QuestionnaireDto questionnaire = new();

            questionnaire.username = "Tudor";
            questionnaire.symptoms = new Dictionary<string, string>();// empty

            ServiceResponse<Dictionary<string, string>> response = await questionnaireService.addQuestionnaire(questionnaire);

            bool expected = false;
            bool actual = false;

            if (response.Success)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }
    }
}
