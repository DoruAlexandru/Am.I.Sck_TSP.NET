using IMSCK.Model;
using IMSCK.Helpers;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using IMSCK.Config;

namespace IMSCK.DAO
{
    public class LoginDao : ILoginDao
    {

        private readonly MySqlConnection conn;

        public LoginDao()
        {

            var config = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json").Build();


            var section = config.GetSection(nameof(DBConfig));
            var dbConfig = section.Get<DBConfig>();

            conn = new MySqlConnection(dbConfig.dbConnectionString);
        }

        public async Task<bool> loginCheck(LoginDto credentials)
        {
            string md5StringPassword = AppHelper.GetMd5Hash(credentials.Password);

            conn.Open();
            string sql = "select * from user where username = @username and password = @hash";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@username", credentials.Username);
            cmd.Parameters.AddWithValue("@hash", md5StringPassword);
            cmd.Prepare();

            MySqlDataReader result = await Task.Run(() =>
            {
                return cmd.ExecuteReader();
            });

            if (result.HasRows)
            {
                conn.Close();
                return true;
            }
            conn.Close();

            return false;
        }

    }
}
