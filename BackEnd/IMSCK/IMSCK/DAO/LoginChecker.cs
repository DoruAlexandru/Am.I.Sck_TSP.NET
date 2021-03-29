using IMSCK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace IMSCK.DAO
{
    public class LoginChecker : LoginInterface
    {

        private MySqlConnection connection;
        private string server;
        private string database;
        private string username;
        private string password;
        private MySqlCommand cmd;
        public LoginChecker()
        {
            server = "localhost";
            database = "tspnet";
            username = "root";
            password = "root";
            connection = new MySqlConnection("SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";");
            connection.Open();
            cmd = connection.CreateCommand();
        }


        public Boolean checkCredentials(LoginDetails credentials)
        {
            cmd.CommandText = "select userName from credentials where userName = '"+credentials.Username+"' and password = '"+credentials.Password+"'";
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader.Read();

        }

        
    }
}