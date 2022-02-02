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
        const string _connectionString = "Data Source=localhost; Initial Catalog=Television; User ID=sa; Password=sa";

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
                int channel, volume, source;
                reader.Read();
                if (reader.HasRows)
                {
                    channel = reader.GetInt32(reader.GetOrdinal("Channel"));
                    volume = reader.GetInt32(reader.GetOrdinal("Volume"));
                    source = reader.GetInt32(reader.GetOrdinal("Source"));
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
        public int GetSource()
        {
            string sql = "SELECT TOP 1 Id, Source FROM TvCurrent" +
                         " ORDER BY Id DESC";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();

                var source = reader.GetInt32(reader.GetOrdinal("Source"));

                return source;
            };
        }
        public void SetCurrentTv(int channel, int volume, int source)
        {
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
                var result = GetCurrentTv();
                if (result[0].Channel == 999)
                {
                    result[0].Channel = 1;
                }
                else
                {
                    result[0].Channel++;
                }
                command.Parameters.AddWithValue("@Channel", result[0].Channel);
                command.Parameters.AddWithValue("@Volume", result[0].Volume);
                command.Parameters.AddWithValue("@Source", result[0].Source);

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
                var result = GetCurrentTv();
                if (result[0].Channel == 1)
                {
                    result[0].Channel = 999;
                }
                else
                {
                    result[0].Channel--;
                }
                command.Parameters.AddWithValue("@Channel", result[0].Channel);
                command.Parameters.AddWithValue("@Volume", result[0].Volume);
                command.Parameters.AddWithValue("@Source", result[0].Source);
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
                var result = GetCurrentTv();
                if (result[0].Volume == 100)
                {
                    result[0].Volume = 100;
                }
                else
                {
                    result[0].Volume++;
                }
                command.Parameters.AddWithValue("@Channel", result[0].Channel);
                command.Parameters.AddWithValue("@Volume", result[0].Volume);
                command.Parameters.AddWithValue("@Source", result[0].Source);

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
                var result = GetCurrentTv();
                if (result[0].Volume == 0)
                {
                    result[0].Volume = 0;
                }
                else
                {
                    result[0].Volume--;
                }
                command.Parameters.AddWithValue("@Channel", result[0].Channel);
                command.Parameters.AddWithValue("@Volume", result[0].Volume);
                command.Parameters.AddWithValue("@Source", result[0].Source);
                connection.Open();
                command.ExecuteNonQuery();

            }
        }
        public void SetSource()
        {
            var sql = "INSERT INTO TvCurrent(Channel, Volume, Source) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var result = GetCurrentTv();
                if (result[0].Source == 1)
                {
                    result[0].Source++;
                    result[0].Channel = 0;
                }
                else if (result[0].Source == 2)
                {
                    result[0].Source++;
                    result[0].Channel = 0;
                }
                else
                {
                    result[0].Source = 1;
                    result[0].Channel = GetLastTvChannel();
                }

                command.Parameters.AddWithValue("@Channel", result[0].Channel);
                command.Parameters.AddWithValue("@Volume", result[0].Volume);
                command.Parameters.AddWithValue("@Source", result[0].Source);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void ClearCurrentTV()
        {
            string sql = "DELETE FROM TvCurrent";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private int GetLastTvChannel()
        {
            int lastTvChannel = 1;
            string sql = "SELECT Id, Channel, Volume, Source FROM TvCurrent" +
                         " ORDER BY Id DESC";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var channel = reader.GetInt32(reader.GetOrdinal("Channel"));
                    var volume = reader.GetInt32(reader.GetOrdinal("Volume"));
                    var source = reader.GetInt32(reader.GetOrdinal("Source"));
                    if (source == 1)
                    {
                        lastTvChannel = channel;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                return lastTvChannel;
            }
        }


    }
}
