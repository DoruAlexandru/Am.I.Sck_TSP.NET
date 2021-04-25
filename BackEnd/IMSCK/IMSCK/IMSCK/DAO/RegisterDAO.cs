using IMSCK.Model;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public class RegisterDAO : IRegisterDAO
    {

        private MySqlConnection conn;

        public RegisterDAO()
        {
            conn = new MySqlConnection("server=localhost;user=root;password=root;database=tspnet");
        }

        public async Task<bool> addUser(RegisterDTO credentials)
        {
            conn.Open();

            if (!findUser(credentials))
            {
                string sql = "insert into user(userName, password) values('" + credentials.Username + "', '" + credentials.Password + "');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();

                if (result != 0)
                {
                    conn.Close();
                    return true;
                }
            }

            conn.Close();
            return false;
        }

        private bool findUser(RegisterDTO credentials)
        {
            string sql = "select * from user where username = '" + credentials.Username + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader result = cmd.ExecuteReader();

            bool resp = result.HasRows;
            result.Close();
            return resp;
            
        }
    }
}
