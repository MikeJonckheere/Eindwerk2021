using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Remote.Models;
using System.Text;

namespace Remote.Repositories
{
    class sqlRepository
    {
        const string _connectionString = "Data Source=localhost; Initial Catalog=Remote; User ID=sa; Password=SQL12345";

        public List<RemoteControl> GetCurrentValues()
        {
            var result = new List<RemoteControl>();

            string sql = "SELECT CurrentChannel FROM Channel SELECT @@IDENTITY";
            string sql2 = "SELECT CurrentVolume FROM Volume SELECT @@IDENTITY";
            string sql3 = "SELECT CurrentSource FROM Source SELECT @@IDENTITY";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            using (var command2 = new SqlCommand(sql2, connection))
            using (var command3 = new SqlCommand(sql3, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();

                var channel = reader.GetInt32(reader.GetOrdinal("CurrentChannel"));
                reader = command2.ExecuteReader();
                var volume = reader.GetInt32(reader.GetOrdinal("CurrentVolume"));
                reader = command3.ExecuteReader();
                var source = reader.GetInt32(reader.GetOrdinal("CurrentSource"));

                var remoteControl = new RemoteControl();
                remoteControl.FillRemote(channel, volume, source);

                result.Add(remoteControl);
            }
            return result;
        }
    }
}
