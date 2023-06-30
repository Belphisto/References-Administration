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
            connection.Open();
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            string query = "SELECT * FROM department";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department department = new Department();
                        department.ID = (int)reader["id"];
                        department.Name = reader["name"].ToString();
                        // Проверка на значение NULL
                        if (!reader.IsDBNull(reader.GetOrdinal("parent_id")))
                        {
                            department.ParentID = (int)reader["parent_id"];
                        }
                        else
                        {
                            department.ParentID = null;
                        }

                        departments.Add(department);
                        Log.WriteLog($"department {department} add to List<Department> departments ");
                    }
                }
            }

            return departments;
        }
    }
}
