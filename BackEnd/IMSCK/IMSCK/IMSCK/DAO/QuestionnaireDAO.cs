using IMSCK.Model;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public class QuestionnaireDAO : IQuestionnaireDAO
    {

        private MySqlConnection conn;

        public QuestionnaireDAO()
        {
            conn = new MySqlConnection("server=localhost;user=root;password=root;database=tspnet");
        }

        public async Task<bool> addQuestionnaire(QuestionnaireDTO questionnaire)
        {
            return false;
        }
    }
}
