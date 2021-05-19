using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IMSCK.Model;
using Microsoft.Extensions.Configuration;
using IMSCK.Config;

namespace IMSCK.DAO
{
    public class QuestionnaireDao : IQuestionnaireDao
    {

        private readonly MySqlConnection conn;

        public QuestionnaireDao()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();


            var section = config.GetSection(nameof(DBConfig));
            var dbConfig = section.Get<DBConfig>();

            conn = new MySqlConnection(dbConfig.dbConnectionString);
        }

        public async Task<int> addQuestionnaire(string username, int severityPercentage)
        {
            conn.Open();
            int idQuestionnaire = await generateIdQuestionnaire();

            string sql = "insert into questionnaire(idQuestionnaire, userName, date, severityPercentage) values (@idQuestionnaire, @username, @date, @severityPercentage);";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idQuestionnaire", idQuestionnaire);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss"));
            cmd.Parameters.AddWithValue("@severityPercentage", severityPercentage);
            cmd.Prepare();

            int result = await Task.Run(() =>
            {
                return cmd.ExecuteNonQuery();
            });

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

            string sql = "delete from questionnairesymptoms where idQuestionnaireSymptoms = @idQuestionnaire";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idQuestionnaire", idQuestionnaire);
            cmd.Prepare();

            int result = await Task.Run(() =>
            {
                return cmd.ExecuteNonQuery();
            });


            if (result == 0)
            {
                conn.Close();
                return false;
            }

            sql = "delete from questionnaire where idQuestionnaire = @idQuestionnaire";
            cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@idQuestionnaire", idQuestionnaire);
            cmd.Prepare();

            result = cmd.ExecuteNonQuery();

            if (result == 0)
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return true;
        }

        public async Task<bool> addQuestionnaireSymptoms(QuestionnaireDto questionnaire, int idQuestionnaire)
        {

            conn.Open();
            List<string> keyList = new List<string>(questionnaire.symptoms.Keys);
            int result = -1;
            foreach (string key in keyList)
            {
                string sql = "insert into questionnairesymptoms(idQuestionnaireSymptoms, symptomName, symptomSeverity) values (@idQuestionnaireSymptoms, @symptomName, @symptomSeverity);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@idQuestionnaireSymptoms", idQuestionnaire);
                cmd.Parameters.AddWithValue("@symptomName", key);
                cmd.Parameters.AddWithValue("@symptomSeverity", questionnaire.symptoms[key]);
                cmd.Prepare();

                result = await Task.Run(() =>
                {
                    return cmd.ExecuteNonQuery();
                });

                if (result == 0)
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
            MySqlDataReader result = await Task.Run(() =>
            {
                return cmd.ExecuteReader();
            });

            result.Read();
            int idQuestionnaire = result.GetInt32(0) + 1;
            result.Close();
            return idQuestionnaire;
        }

        public async Task<List<Dictionary<string, string>>> getQuestionnaires(string username)
        {
            conn.Open();
            string sql = "SELECT idQuestionnaire, userName, date, severityPercentage FROM questionnaire WHERE userName = @username";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Prepare();

            MySqlDataReader result = await Task.Run(() =>
            {
                return cmd.ExecuteReader();
            });

            List<Dictionary<string, string>> questionnaires = new List<Dictionary<string, string>>();
            Dictionary<string, string> questionnaire;

            while (result.Read())
            {
                questionnaire = new Dictionary<string, string>();
                questionnaire.Add("id", result.GetInt32(0).ToString());
                questionnaire.Add("username", result.GetString(1));
                questionnaire.Add("date", result.GetDateTime(2).ToString());
                questionnaire.Add("severityPercentage", result.GetInt32(3).ToString());
                questionnaires.Add(questionnaire);
            }

            conn.Close();
            System.Console.WriteLine(questionnaires.Count);

            return questionnaires;
        }

        public async Task<List<Dictionary<string, string>>> getQuestionnaireSymptoms(string username, int id)
        {
            conn.Open();
            string sql = "SELECT qs.idQuestionnaireSymptoms, qs.symptomName, qs.symptomSeverity FROM questionnairesymptoms qs" +
                " JOIN questionnaire q ON q.idQuestionnaire = qs.idQuestionnaireSymptoms WHERE q.userName = @username" +
                " AND q.idQuestionnaire = @id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            MySqlDataReader result = await Task.Run(() =>
            {
                return cmd.ExecuteReader();
            });

            List<Dictionary<string, string>> symptoms = new List<Dictionary<string, string>>();
            Dictionary<string, string> symptom;

            while (result.Read())
            {
                symptom = new Dictionary<string, string>();
                symptom.Add("id", result.GetInt32(0).ToString());
                symptom.Add("name", result.GetString(1));
                symptom.Add("severity", result.GetInt32(2).ToString());
                symptoms.Add(symptom);
            }

            conn.Close();
            System.Console.WriteLine(symptoms.Count);

            return symptoms;
        }
    }
}
