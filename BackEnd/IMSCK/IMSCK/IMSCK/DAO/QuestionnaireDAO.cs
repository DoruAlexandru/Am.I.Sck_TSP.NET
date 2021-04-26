using IMSCK.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        public async Task<int> addQuestionnaire(string username, int severityPercentage)
        {
            conn.Open();
            int idQuestionnaire = await generateIdQuestionnaire();

            System.Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss"));

            string sql = "insert into questionnaire(idQuestionnaire, userName, date, severityPercentage) values ("+
                idQuestionnaire +", '"+ username + "', '"+ DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss") + "', "+severityPercentage + ");";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();

            if (result != 0)
            {
                conn.Close();
                return idQuestionnaire;
            }
            conn.Close();
            return -1;
        }

        public async Task<bool> rollbackAddQuestionnaire(int idQuestionnaire)
        {
            conn.Open();

            string sql = "delete from questionnairesymptoms where idQuestionnaireSymptoms = " + idQuestionnaire;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result == 0)
            {
                conn.Close();
                return false;
            }

            sql = "delete from questionnaire where idQuestionnaire = "+idQuestionnaire;
            cmd = new MySqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();

            if (result == 0)
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return true;
        }

        public async Task<bool> addQuestionnaireSymptoms(QuestionnaireDTO questionnaire, int idQuestionnaire)
        {

            conn.Open();
            List<string> keyList = new List<string>(questionnaire.symptoms.Keys);
            int result = -1;
            foreach (string key in keyList)
            {
                string sql = "insert into questionnairesymptoms(idQuestionnaireSymptoms, symptomName, symptomSeverity) values (" +
                    idQuestionnaire + ", '" + key + "', '" + questionnaire.symptoms[key] + "');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                result = cmd.ExecuteNonQuery();

                if(result == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private async Task<int> generateIdQuestionnaire()
        {
            string sql = "select count(idQuestionnaire) from questionnaire;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader result = cmd.ExecuteReader();
            result.Read();
            int idQuestionnaire = result.GetInt32(0)+1;
            result.Close();
            return idQuestionnaire;
        }
    }
}
