using IMSCK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public interface IQuestionnaireDAO
    {
        public Task<bool> addQuestionnaire(QuestionnaireDTO credentials);
    }
}
