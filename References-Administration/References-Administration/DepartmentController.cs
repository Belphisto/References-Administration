using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class DepartmentController
    {
        public static List<Department> GetDepartments(NpgsqlConnection connection)
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
    }
}
