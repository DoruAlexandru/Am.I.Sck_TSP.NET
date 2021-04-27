using IMSCK.Model;
using IMSCK.Helpers;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using IMSCK.Config;

namespace IMSCK.DAO
{
    public class LoginDAO : ILoginDAO
    {

        private MySqlConnection conn;

        public LoginDAO()
        {

            var config = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json").Build();


            var section = config.GetSection(nameof(DBConfig));
            var dbConfig = section.Get<DBConfig>();

            conn = new MySqlConnection(dbConfig.dbConnectionString);
        }

        public async Task<bool> loginCheck(LoginDTO credentials)
        {
            string md5StringPassword = AppHelper.GetMd5Hash(credentials.Password);

            conn.Open();
            string sql = "select * from user where username = '" + credentials.Username + "' and password = '" + md5StringPassword + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader result = cmd.ExecuteReader();
            
            if (result.HasRows == true)
            {
                conn.Close();
                return true;
            }
            conn.Close();

            return false;
        }

    }
}
