using IMSCK.Model;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public class LoginDAO : ILoginDAO
    {

        private MySqlConnection conn;

        public LoginDAO()
        {
            conn = new MySqlConnection("server=localhost;user=root;password=root;database=tspnet");
        }

        public async Task<bool> loginCheck(LoginDTO credentials)
        {
            conn.Open();
            string sql = "select * from user where username = '" + credentials.Username + "' and password = '" + credentials.Password + "'";
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
