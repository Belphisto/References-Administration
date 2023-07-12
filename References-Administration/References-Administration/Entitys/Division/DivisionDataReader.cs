using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class DivisionDataReader : IDivisionDataReader
    {
        private readonly NpgsqlConnection _connection;

        public DivisionDataReader(DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public string GetDepartmentName(int id)
        {
            Division department = Read(id);
            string name = department.Name;
            return name;
        }

        public List<Division> GetDepartments()
        {
            List<Division> departments = new List<Division>();

            string query = "SELECT * FROM department";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Division department = new Division();
                        department.ID = (int)reader["id"];
                        department.Name = reader["name"].ToString();
                        // Проверка на значение NULL
                        if (!reader.IsDBNull(reader.GetOrdinal("parent_id")))
                            department.ParentID = (int)reader["parent_id"];
                        else
                            department.ParentID = null;

                        departments.Add(department);
                        Log.WriteLog($"DepartmentController/GetDepartments(NpgsqlConnection connection)/ department {department} add to List<Department> departments ");
                    }
                }
            }
            return departments;
        }

        public Division Read(int departmentID)
        {
            Division department = null;
            string query = "SELECT * FROM department WHERE id = @DepartmentID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@DepartmentID", departmentID);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        department = new Division();
                        department.ID = (int)reader["id"];
                        department.Name = reader["name"].ToString();
                        department.ParentID = reader["parent_id"] != DBNull.Value ? (int?)Convert.ToInt32(reader["parent_id"]) : null;
                    }
                }
            }
            return department;
        }

        public Division Read(string departmentName)
        {
            Division department = null;
            string query = "SELECT * FROM department WHERE name = @DepartmentName";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@DepartmentName", departmentName);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        department = new Division();
                        department.ID = (int)reader["id"];
                        department.Name = reader["name"].ToString();
                        department.ParentID = reader["parent_id"] != DBNull.Value ? (int?)Convert.ToInt32(reader["parent_id"]) : null;
                    }
                }
            }
            return department;
        }
    }
}
