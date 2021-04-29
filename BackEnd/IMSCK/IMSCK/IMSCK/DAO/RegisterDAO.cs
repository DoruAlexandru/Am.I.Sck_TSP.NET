using IMSCK.Model;
using IMSCK.Helpers;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using IMSCK.Config;
using System;

namespace IMSCK.DAO
{
    public class RegisterDao : IRegisterDao
    {

        private readonly MySqlConnection conn;

        public RegisterDao()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();


            var section = config.GetSection(nameof(DBConfig));
            var dbConfig = section.Get<DBConfig>();

            conn = new MySqlConnection(dbConfig.dbConnectionString);
        }

        public async Task<bool> addUser(RegisterDto credentials)
        {
            conn.Open();

            if ( ! await findUser(credentials))
            {
                string md5StringPassword = AppHelper.GetMd5Hash(credentials.Password);

                string sql = "insert into user(userName, password) values('" + credentials.Username + "', '" + md5StringPassword + "');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = await Task.Run(() =>
                {
                    return cmd.ExecuteNonQuery();
                });

                if (result != 0)
                {
                    conn.Close();
                    return true;
                }
            }

            conn.Close();
            return false;
        }

        private async Task<bool> findUser(RegisterDto credentials)
        {
            string sql = "select * from user where username = '" + credentials.Username + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader result = await Task.Run(() =>
            {
                return cmd.ExecuteReader();
            });

            bool resp = result.HasRows;
            result.Close();
            return resp;
            
        }
    }
}
