using System;
using MySql.Data.MySqlClient;

namespace SoccerstarClassicTool
{
    internal class Connection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string userId;
        private string password;

        public Connection()
        {
            // Load the settings
            server = SoccerStarClassicTool_remaster.Properties.Settings.Default.Server;
            database = SoccerStarClassicTool_remaster.Properties.Settings.Default.Database;
            userId = SoccerStarClassicTool_remaster.Properties.Settings.Default.UserId;
            password = SoccerStarClassicTool_remaster.Properties.Settings.Default.Password;

            string connectionString = $"Server={server};Database={database};Uid={userId};Pwd={password};";
            connection = new MySqlConnection(connectionString);
        }

        public void Open()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void Close()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public string TestConnection()
        {
            try
            {
                Open();
                Close();
                return "Connection successful.";
            }
            catch (Exception ex)
            {
                return $"Connection failed: {ex.Message}";
            }
        }
    }
}
