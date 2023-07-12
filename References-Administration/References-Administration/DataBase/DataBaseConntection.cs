using Npgsql;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class DataBaseConntection : IDataBaseConnection
    {
        private readonly NpgsqlConnection _connection;

        public DataBaseConntection()
        {
            string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=References_Administration";
            _connection = new NpgsqlConnection(connectionString);
            Log.WriteLog($"DataBaseController/DataBaseController()/ соединение {_connection} открыто успешно ");
            _connection.Open();
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                Log.WriteLog($"DataBaseController/CloseConnection()/ соединение {_connection} завершено успешно ");
            }
        }

        public NpgsqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
