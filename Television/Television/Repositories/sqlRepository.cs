using System;
using System.Collections.Generic;
using Television.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Television.Repositories
{
    class sqlRepository
    {
        const string _connectionString = "Data Source=localhost; Initial Catalog=Television; User ID=sa; Password=SQL12345";
        
        public List<Tele> GetCurrentValues()
        {
            var result = new List<Tele>();

            string sql = "SELECT TOP 1 SettingsId, SettingsChannel, SettingsVolume, SettingsSource FROM TvSettings" +
                         " ORDER BY SettingsId DESC";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();

                var settingsChannel = reader.GetInt32(reader.GetOrdinal("SettingsChannel"));
                var settingsVolume = reader.GetInt32(reader.GetOrdinal("SettingsVolume"));
                var settingsSource = reader.GetInt32(reader.GetOrdinal("SettingsSource"));

                var tele = new Tele();
                tele.FillTele(settingsChannel, settingsVolume, settingsSource);

                result.Add(tele);

            }
            return result;
        }

    }
}
