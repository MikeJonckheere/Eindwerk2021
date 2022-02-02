using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Remote.Models;
using System.Text;


namespace Remote.Repositories
{

    class sqlRepository
    {
        public static int oldVolume, newVolume, oldChannel, newChannel,channelDefault, volumeDefault, sourceDefault;
        static string isOldSource = null;
        static string isNewSource = null;
        const string _connectionString = "Data Source=localhost; Initial Catalog=Television; User ID=sa; Password=sa";
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
        public List<RemoteControl> GetTvSettings()
        {
            var result = new List<RemoteControl>();

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
                var remote = new RemoteControl();
                remote.FillRemote(channel, volume, source);
                result.Add(remote);
            }
            return result;
        }
        public List<RemoteControl> GetCurrentTv()
        {
            var result = new List<RemoteControl>();

            string sql = "SELECT TOP 1 Id, Channel, Volume, Source FROM TvCurrent" +
                         " ORDER BY Id DESC";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                int channel, volume, source;
                if (reader.HasRows)
                {
                    channel = reader.GetInt32(reader.GetOrdinal("Channel"));
                    volume = reader.GetInt32(reader.GetOrdinal("Volume"));
                    source = reader.GetInt32(reader.GetOrdinal("Source"));
                }
                //voorkomen dat television crasht wanneer source hdmi1, hdmi2 bij tv settings aan staat.
                //Worker blijft draaien met methode GetCurrentTv() om te voorkomen dat de worker crasht vullen we tijdelijke waarden in object.
                //Bij opstart tv worden tvSettings ingeladen.

                else
                {
                    channel = 1;
                    volume = 1;
                    source = 1;
                }

                var remote = new RemoteControl();
                remote.FillRemote(channel, volume, source);
                result.Add(remote);
            }
            return result;
        }

        public void SetCurrentTv(int channel, int volume, int source)
        {
            var result = new List<RemoteControl>();
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

        public (int, int) ChannelUp()
        {
            oldChannel = 0;
            newChannel = 0;
            var sql = "INSERT INTO TvCurrent(Channel, Volume, Source) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var result = GetCurrentTv();
                oldChannel = result[0].Channel;
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
                newChannel = result[0].Channel;
                connection.Open();
                command.ExecuteNonQuery();
                return (oldChannel, newChannel);
            }
        }
        public (int, int) ChannelDown()
        {
            oldChannel = 0;
            newChannel = 0;
            var sql = "INSERT INTO TvCurrent(Channel, Volume, Source) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var result = GetCurrentTv();
                oldChannel = result[0].Channel;
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
                newChannel = result[0].Channel;
                connection.Open();
                command.ExecuteNonQuery();
                return (oldChannel, newChannel);
            }
        }
        public (int, int) VolumeUp()
        {
            oldVolume = 0;
            newVolume = 0;
            var sql = "INSERT INTO TvCurrent(Channel, Volume, Source) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var result = GetCurrentTv();
                oldVolume = result[0].Volume;

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
                newVolume = result[0].Volume;
                connection.Open();
                command.ExecuteNonQuery();
                return (oldVolume, newVolume);
            }
        }
        public (int, int) VolumeDown()
        {
            oldVolume = 0;
            newVolume = 0;
            var sql = "INSERT INTO TvCurrent(Channel, Volume, Source) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var result = GetCurrentTv();
                oldVolume = result[0].Volume;
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
                newVolume = result[0].Volume;
                connection.Open();
                command.ExecuteNonQuery();
                return (oldVolume, newVolume);
            }
        }
        public (string, string) SetSource()
        {
             var sql = "INSERT INTO TvCurrent(Channel, Volume, Source) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var result = GetCurrentTv();
                
                Sourcename isOld = (Sourcename)result[0].Source;

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
                Sourcename isNew = (Sourcename)result[0].Source;
                connection.Open();
                command.ExecuteNonQuery();

                
                isOldSource = isOld.ToString();
                isNewSource = isNew.ToString();
            }
            return (isOldSource,isNewSource);
        }
        public int GetLastTvChannel()
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
        public (int, int, int) SetTvSettings()
        {
            channelDefault = 0;
            volumeDefault = 0;
            sourceDefault = 0;
            var sql = "INSERT INTO TvSettings(SettingsChannel, SettingsVolume, SettingsSource) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var result = GetCurrentTv();
                command.Parameters.AddWithValue("@Channel", result[0].Channel);
                channelDefault = result[0].Channel;
                command.Parameters.AddWithValue("@Volume", result[0].Volume);
                volumeDefault = result[0].Volume;
                command.Parameters.AddWithValue("@Source", result[0].Source);
                sourceDefault = result[0].Source;
                connection.Open();
                command.ExecuteNonQuery();
            }
            return (channelDefault, volumeDefault, sourceDefault);
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
        public bool SendChannelNumPad(string numpad)
        {
            bool success = false;
            //omzetten string numpad naar int
            newChannel = Int32.Parse(numpad);

            var sql = "INSERT INTO TvCurrent(Channel, Volume, Source) VALUES (@Channel, @Volume, @Source)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                var result = GetCurrentTv();
                if (newChannel > 0 && newChannel <= 999)
                {
                    result[0].Channel = newChannel;
                    success = true;
                    command.Parameters.AddWithValue("@Channel", result[0].Channel);
                    command.Parameters.AddWithValue("@Volume", result[0].Volume);
                    command.Parameters.AddWithValue("@Source", result[0].Source);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                else
                {
                    success = false;
                }
                return success;
            }

        }

    }
}
