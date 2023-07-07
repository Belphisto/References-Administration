using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class DataBaseController
    {
        private NpgsqlConnection connection; // Подключение к базе данных PostgreSQL

        public NpgsqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public DataBaseController()
        {
            string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=References_Administration";
            connection = new NpgsqlConnection(connectionString);
            Log.WriteLog($"DataBaseController/DataBaseController()/ соединение {connection} открыто успешно ");
            connection.Open();
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                Log.WriteLog($"DataBaseController/CloseConnection()/ соединение {connection} завершено успешно ");
            }
        }
    }
}
