﻿using IMSCK.Config;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public class SymptomsDAO : ISymptomsDAO
    {
        private MySqlConnection conn;

        public SymptomsDAO()
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json").Build();


            var section = config.GetSection(nameof(DBConfig));
            var dbConfig = section.Get<DBConfig>();

            conn = new MySqlConnection(dbConfig.dbConnectionString);
        }

        public async Task<List<Dictionary<string, string>>> getSymptoms()
        {
            conn.Open();
            string sql = "select symptomName, symptomDescription from symptom;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader result = cmd.ExecuteReader();

            List<Dictionary<string, string>> symptoms = new List<Dictionary<string, string>>();
            Dictionary<string, string> symptom = new Dictionary<string, string>();

            while (result.Read())
            {
                symptom = new Dictionary<string, string>();
                symptom.Add("name",result.GetString(0));
                symptom.Add("description",result.GetString(1));
                symptoms.Add(symptom);
            }

            conn.Close();
            System.Console.WriteLine(symptoms.Count);
            return symptoms;
        }
    }
}
