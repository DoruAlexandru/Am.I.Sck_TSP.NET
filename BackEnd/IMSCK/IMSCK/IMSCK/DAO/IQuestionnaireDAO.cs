using IMSCK.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public interface IQuestionnaireDao
    {
        public Task<int> addQuestionnaire(string username, int severityPercentage);
        public Task<bool> addQuestionnaireSymptoms(QuestionnaireDto questionnaire, int idQuestionnaire);
        public Task<bool> rollbackAddQuestionnaire(int idQuestionnaire);
        public Task<List<Dictionary<string, string>>> getQuestionnaires(string username);
        public Task<List<Dictionary<string, string>>> getQuestionnaireSymptoms(string username, int id);
    }
}
