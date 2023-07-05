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

        // CRUD операции
        // Создание нового подразделения
        public static void Create(NpgsqlConnection connection, Department department)
        {
            string query = "INSERT INTO department (name, parent_id) VALUES (@Name, @ParentID)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", department.Name);
                if (department.ParentID.HasValue)
                    command.Parameters.AddWithValue("@ParentID", department.ParentID);
                else
                    command.Parameters.AddWithValue("@ParentID", DBNull.Value);
                command.ExecuteNonQuery();
            }
        }

        // Чтение данных подразделения по его идентификатору
        public static Department Read(NpgsqlConnection connection, int? departmentID)
        {
            Department department = null;
            string query = "SELECT * FROM department WHERE id = @DepartmentID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DepartmentID", departmentID);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        department = new Department();
                        department.ID = (int)reader["id"];
                        department.Name = reader["name"].ToString();
                        department.ParentID = reader["parent_id"] != DBNull.Value ? (int?)Convert.ToInt32(reader["parent_id"]) : null;
                    }
                }
            }
            return department;
        }

        // Чтение данных подразделения по его наименованию
        public static Department Read(NpgsqlConnection connection, string departmentName)
        {
            Department department = null;
            string query = "SELECT * FROM department WHERE name = @DepartmentName";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DepartmentName", departmentName);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        department = new Department();
                        department.ID = (int)reader["id"];
                        department.Name = reader["name"].ToString();
                        department.ParentID = reader["parent_id"] != DBNull.Value ? (int?)Convert.ToInt32(reader["parent_id"]) : null;
                    }
                }
            }
            return department;
        }


        // Обновление данных подразделения
        public static void Update(NpgsqlConnection connection, Department department)
        {
            string query = "UPDATE department SET name = @Name, parent_id = @ParentID WHERE id = @DepartmentID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DepartmentID", department.ID);
                command.Parameters.AddWithValue("@Name", department.Name);
                command.Parameters.AddWithValue("@ParentID", department.ParentID);

                command.ExecuteNonQuery();
            }
        }

        // Удаление подразделения по его идентификатору
        public static void Delete(NpgsqlConnection connection, Department department)
        {
            // Получить идентификатор родительского подразделения
            int? parentID = department.ParentID;

            // Проверить, есть ли пользователи, относящиеся к текущему подразделению
            string checkUsersQuery = "SELECT COUNT(*) FROM client WHERE id_department = @DepartmentID";
            using (NpgsqlCommand checkUsersCommand = new NpgsqlCommand(checkUsersQuery, connection))
            {
                checkUsersCommand.Parameters.AddWithValue("@DepartmentID", department.ID);
                int usersCount = Convert.ToInt32(checkUsersCommand.ExecuteScalar());

                if (parentID == null && usersCount > 0)
                {
                    // Если у подразделения нет родителя и есть пользователи, не разрешаем удаление подразделения
                    throw new InvalidOperationException("Невозможно удалить подразделение, так как к нему привязаны пользователи.");
                }
            }

            // Обновить ссылки на родителя в дочерних подразделениях
            string updateQuery = "UPDATE department SET parent_id = @NewParentID WHERE parent_id = @DepartmentID";
            using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@NewParentID", parentID);
                updateCommand.Parameters.AddWithValue("@DepartmentID", department.ID);
                updateCommand.ExecuteNonQuery();
            }

            // Обновить привязку пользователей к родительскому подразделению
            string updateClientsQuery = "UPDATE client SET id_department = @NewDepartmentID WHERE id_department = @DepartmentID";
            using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateClientsQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@NewDepartmentID", parentID);
                updateCommand.Parameters.AddWithValue("@DepartmentID", department.ID);
                updateCommand.ExecuteNonQuery();
            }

            // Удалить текущее подразделение из базы данных
            string deleteQuery = "DELETE FROM department WHERE id = @DepartmentID";
            using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, connection))
            {
                deleteCommand.Parameters.AddWithValue("@DepartmentID", department.ID);
                deleteCommand.ExecuteNonQuery();
            }
        }
    }
}
