using System.Collections.Generic;
using System.Data.SqlClient;
using Shared.Models;

namespace Shared.Repositories
{
    public class SqlRepository
    {
        const string _connectionString = "Data Source=localhost; Initial Catalog=Television; User ID=sa; Password=sa";

        public Tele GetLastTvSettings()
        {
            var result = new List<Tele>();

            string sql = "SELECT TOP 1 SettingsId, SettingsChannel, SettingsVolume, SettingsSource FROM TvSettings" +
                         " ORDER BY SettingsId DESC";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                int id, channel, volume, source;
                reader.Read();
                if (reader.HasRows)
                {
                    id = reader.GetInt32(reader.GetOrdinal("SettingsId"));
                    channel = reader.GetInt32(reader.GetOrdinal("SettingsChannel"));
                    volume = reader.GetInt32(reader.GetOrdinal("SettingsVolume"));
                    source = reader.GetInt32(reader.GetOrdinal("SettingsSource"));
                }
                else
                {
                    id = 1;
                    channel = 1;
                    volume = 1;
                    source = 1;
                }
                var tele = new Tele(id, channel, volume, source);
                result.Add(tele);

            }
            return result[result.Count - 1];
        }
        public Tele GetLastTvCurrentTv()
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

                var id = reader.GetInt32(reader.GetOrdinal("Id"));
                var channel = reader.GetInt32(reader.GetOrdinal("Channel"));
                var volume = reader.GetInt32(reader.GetOrdinal("Volume"));
                var source = reader.GetInt32(reader.GetOrdinal("Source"));

                var tele = new Tele(id, channel, volume, source);
                result.Add(tele);
            }
            return result[result.Count - 1];

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

                var id = reader.GetInt32(reader.GetOrdinal("Id"));
                var channel = reader.GetInt32(reader.GetOrdinal("Channel"));
                var volume = reader.GetInt32(reader.GetOrdinal("Volume"));
                var source = reader.GetInt32(reader.GetOrdinal("Source"));

                var tele = new Tele(id, channel, volume, source);
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
        public void SetPowerStatus(bool powerOn)
        {
            var sql = "INSERT INTO TvPower(PowerStatus) VALUES(@PowerStatus)";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@PowerStatus", powerOn);
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
                var tv = GetLastTvCurrentTv();

                if (tv.Channel == 999)
                {
                    tv.Channel = 1;
                }
                else
                {
                    tv.Channel++;
                }
                command.Parameters.AddWithValue("@Channel", tv.Channel);
                command.Parameters.AddWithValue("@Volume", tv.Volume);
                command.Parameters.AddWithValue("@Source", tv.Source);

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
                var tv = GetLastTvCurrentTv();

                if (tv.Channel == 1)
                {
                    tv.Channel = 999;
                }
                else
                {
                    tv.Channel--;
                }
                command.Parameters.AddWithValue("@Channel", tv.Channel);
                command.Parameters.AddWithValue("@Volume", tv.Volume);
                command.Parameters.AddWithValue("@Source", tv.Source);

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
                var tv = GetLastTvCurrentTv();
                if (tv.Volume == 100)
                {
                    tv.Volume = 100;
                }
                else
                {
                    tv.Volume++;
                }
                command.Parameters.AddWithValue("@Channel", tv.Channel);
                command.Parameters.AddWithValue("@Volume", tv.Volume);
                command.Parameters.AddWithValue("@Source", tv.Source);

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
                var tv = GetLastTvCurrentTv();
                if (tv.Volume == 0)
                {
                    tv.Volume = 0;
                }
                else
                {
                    tv.Volume--;
                }
                command.Parameters.AddWithValue("@Channel", tv.Channel);
                command.Parameters.AddWithValue("@Volume", tv.Volume);
                command.Parameters.AddWithValue("@Source", tv.Source);

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
                var tv = GetLastTvCurrentTv();
                if (tv.Source == 1)
                {
                    tv.Source++;
                    tv.Channel = 0;
                }
                else if (tv.Source == 2)
                {
                    tv.Source++;
                    tv.Channel = 0;
                }
                else
                {
                    tv.Source = 1;
                    tv.Channel = 1;
                }

                command.Parameters.AddWithValue("@Channel", tv.Channel);
                command.Parameters.AddWithValue("@Volume", tv.Volume);
                command.Parameters.AddWithValue("@Source", tv.Source);

                connection.Open();
                command.ExecuteNonQuery();

            }


        }
    }


}
