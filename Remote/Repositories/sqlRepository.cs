using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Remote.Models;
using System.Text;

namespace Remote.Repositories
{
    class sqlRepository
    {
        const string _connectionString = "Data Source=localhost; Initial Catalog=Television; User ID=sa; Password=SQL12345";

        public List<RemoteControl> GetCurrentValues()
        {
            var result = new List<RemoteControl>();

            string sql = "SELECT Channel, Volume, Source FROM TvCurrent SELECT @@IDENTITY";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();

                var channel = reader.GetInt32(reader.GetOrdinal("Channel"));
                var volume = reader.GetInt32(reader.GetOrdinal("Volume"));
                var source = reader.GetInt32(reader.GetOrdinal("Source"));

                var remoteControl = new RemoteControl();
                remoteControl.FillRemote(channel, volume, source);

                result.Add(remoteControl);
            }
            return result;
        }
    }
}
