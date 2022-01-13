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

        public List<Tele> GetTvSettings()
        {
            var result = new List<Tele>();

            string sql = "SELECT TOP 1 SettingsId, SettingsChannel, SettingsVolume, SettingsSource FROM TvSettings" +
                         " ORDER BY SettingsId DESC";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                int channel, volume, source;
                reader.Read();
                if (reader.HasRows)
                {
                    channel = reader.GetInt32(reader.GetOrdinal("SettingsChannel"));
                    volume = reader.GetInt32(reader.GetOrdinal("SettingsVolume"));
                    source = reader.GetInt32(reader.GetOrdinal("SettingsSource"));
                }
                else
                {
                    channel = 1;
                    volume = 1;
                    source = 1;
                }
                var tele = new Tele();
                tele.FillTele(channel, volume, source);
                result.Add(tele);

            }
            return result;
        }
        public List<Tele> GetCurrentTv()
        {
            var result = new List<Tele>();

            string sql = "SELECT TOP 1 Id, Channel, Volume, Source FROM TvCurrent" +
                         " ORDER BY Id DESC";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();

                var channel = reader.GetInt32(reader.GetOrdinal("Channel"));
                var volume = reader.GetInt32(reader.GetOrdinal("Volume"));
                var source = reader.GetInt32(reader.GetOrdinal("Source"));

                var tele = new Tele();
                tele.FillTele(channel, volume, source);
                result.Add(tele);
            }
            return result;

        }
        public void SetCurrentTv(int channel, int volume, int source)
        {
            var result = new List<Tele>();
            string sql = "INSERT INTO TvCurrent(Channel, Volume, Source)" +
                "VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Channel", channel);
                command.Parameters.AddWithValue("@Volume", volume);
                command.Parameters.AddWithValue("@Source", source);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool GetPowerStatus()
        {
            bool result;

            string sql = "SELECT TOP 1 PowerStatus FROM TvPower ORDER BY PowerId DESC";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    result = reader.GetBoolean(reader.GetOrdinal("PowerStatus"));
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }
        public void SetPowerStatus(byte powerOnOff)
        {
            var sql = "INSERT INTO TvPower(PowerStatus) VALUES(@PowerStatus)";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@PowerStatus", powerOnOff);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void ChannelUp()
        {
            var sql = "INSERT INTO TvCurrent(Channel, Volume, Source) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var results = GetCurrentTv();
                foreach (var result in results)
                {
                    if (result.Channel == 999)
                    {
                        result.Channel = 1;
                    }
                    else
                    {
                        result.Channel++;
                    }
                    command.Parameters.AddWithValue("@Channel", result.Channel);
                    command.Parameters.AddWithValue("@Volume", result.Volume);
                    command.Parameters.AddWithValue("@Source", result.Source);
                }
                connection.Open();
                command.ExecuteNonQuery();

            }
        }
        public void ChannelDown()
        {
            var sql = "INSERT INTO TvCurrent(Channel, Volume, Source) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var results = GetCurrentTv();
                foreach (var result in results)
                {
                    if (result.Channel == 1)
                    {
                        result.Channel = 999;
                    }
                    else
                    {
                        result.Channel--;
                    }
                    command.Parameters.AddWithValue("@Channel", result.Channel);
                    command.Parameters.AddWithValue("@Volume", result.Volume);
                    command.Parameters.AddWithValue("@Source", result.Source);
                }
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void VolumeUp()
        {
            var sql = "INSERT INTO TvCurrent(Channel, Volume, Source) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var results = GetCurrentTv();
                foreach (var result in results)
                {
                    if (result.Volume == 100)
                    {
                        result.Volume = 100;
                    }
                    else
                    {
                        result.Volume++;
                    }
                    command.Parameters.AddWithValue("@Channel", result.Channel);
                    command.Parameters.AddWithValue("@Volume", result.Volume);
                    command.Parameters.AddWithValue("@Source", result.Source);
                }
                connection.Open();
                command.ExecuteNonQuery();

            }
        }
        public void VolumeDown()
        {
            var sql = "INSERT INTO TvCurrent(Channel, Volume, Source) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var results = GetCurrentTv();
                foreach (var result in results)
                {
                    if (result.Volume == 0)
                    {
                        result.Volume = 0;
                    }
                    else
                    {
                        result.Volume--;
                    }
                    command.Parameters.AddWithValue("@Channel", result.Channel);
                    command.Parameters.AddWithValue("@Volume", result.Volume);
                    command.Parameters.AddWithValue("@Source", result.Source);
                }
                connection.Open();
                command.ExecuteNonQuery();

            }
        }



    }
}
