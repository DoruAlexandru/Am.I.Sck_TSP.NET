using IMSCK.Config;
using IMSCK.Model;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using System.Linq;
using System.Text.Json;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;

namespace IMSCK.DAO
{
    public class NurseDao : INurseDao
    {
        private readonly MySqlConnection conn;

        private readonly string GoogleApiKey;

        public NurseDao()
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json").Build();

            var section = config.GetSection(nameof(DBConfig));
            var dbConfig = section.Get<DBConfig>();

            conn = new MySqlConnection(dbConfig.dbConnectionString);

            this.GoogleApiKey = "AIzaSyCuBO0z7s3bO5pqCB_RKQcmLh5cPt2XML8";
        }

        public async Task<List<Dictionary<string, string>>> getNurses(CoordinatesDto credentials)
        {
            conn.Open();
            string sql = "select id, fullName, location from nurse";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader result = await Task.Run(() =>
            {
                return cmd.ExecuteReader();
            });

            List<Dictionary<string, string>> nurses = new List<Dictionary<string, string>>();
            Dictionary<string, string> nurse;

            while (result.Read())
            {
                string locationJson = result.GetString(2);
                
                Location startingLocation = new Location(credentials.Latitude, credentials.Longitude);
                CoordinatesDto nurseLocation = JsonSerializer.Deserialize<CoordinatesDto>(locationJson);
                Location destinationLocation = new Location(nurseLocation.Latitude, nurseLocation.Longitude);

                double distance = this.getDistance(startingLocation, destinationLocation);

                if (distance <= 100000) 
                {// less than 100km
                    string nurseAddress = this.getFormattedAddress(destinationLocation);

                    string distanceKm = String.Format("{0:0.00}km", (distance / 1000));

                    nurse = new Dictionary<string, string>();
                    nurse.Add("id", result.GetInt32(0).ToString());
                    nurse.Add("name", result.GetString(1));
                    nurse.Add("location", nurseAddress);
                    nurse.Add("distance", distanceKm);
                    nurses.Add(nurse);
                }
            }

            conn.Close();
            return nurses;
        }

        public double getDistance(Location startingLocation, Location destinationLocation)
        {
            DirectionsRequest request = new DirectionsRequest();
            request.Key = this.GoogleApiKey;
            request.Origin = startingLocation;
            request.Destination = destinationLocation;

            var response_gmaps = GoogleApi.GoogleMaps.Directions.Query(request);
            double distance = response_gmaps.Routes.First().Legs.First().Distance.Value;

            return distance;
        }

        public string getFormattedAddress(Location location)
        {

            LocationGeocodeRequest request = new LocationGeocodeRequest();
            request.Key = this.GoogleApiKey;
            request.Location = location;
            var response_geocode = GoogleApi.GoogleMaps.LocationGeocode.Query(request);

            string address = response_geocode.Results.First().FormattedAddress.ToString();

            return address;
        }
    }
}
