using IMSCK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public interface IQuestionnaireDAO
    {
        public Task<int> addQuestionnaire(string username, int severityPercentage);
        public Task<bool> addQuestionnaireSymptoms(QuestionnaireDTO credentials, int idQuestionnaire);

        public Task<bool> rollbackAddQuestionnaire(int idQuestionnaire);
    }
}
