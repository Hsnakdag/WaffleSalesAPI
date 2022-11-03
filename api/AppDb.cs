
using System;
using MySqlConnector;

namespace api
{
    public class AppDb : IDisposable
    {
        public MySqlConnection Connection { get;  }

        public AppDb(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }
        public void Dispose() => Connection.Dispose();
    }
}
