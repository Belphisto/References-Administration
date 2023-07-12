using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class DivisionDataWriter : IDivisionDataWriter
    {
        private readonly NpgsqlConnection _connection;
        private readonly IDivisionHollWriter _divisionHollWriter;

        public DivisionDataWriter(DataBaseConntection connection, IDivisionHollWriter divisionHollWriter)
        {
            _connection = connection.GetConnection();
            _divisionHollWriter = divisionHollWriter;
        }

        public void CheckUsers(Division department)
        {
            int? parentID = department.ParentID;

            string checkUsersQuery = "SELECT COUNT(*) FROM client WHERE id_department = @DepartmentID";
            using (NpgsqlCommand checkUsersCommand = new NpgsqlCommand(checkUsersQuery, _connection))
            {
                checkUsersCommand.Parameters.AddWithValue("@DepartmentID", department.ID);
                int usersCount = Convert.ToInt32(checkUsersCommand.ExecuteScalar());

                if (parentID == null && usersCount > 0)
                {
                    throw new InvalidOperationException("Невозможно удалить подразделение, так как к нему привязаны пользователи.");
                }
            }
        }

        public void Create(Division department)
        {
            string query = "INSERT INTO department (name, parent_id) VALUES (@Name, @ParentID)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Name", department.Name);
                if (department.ParentID.HasValue)
                    command.Parameters.AddWithValue("@ParentID", department.ParentID);
                else
                    command.Parameters.AddWithValue("@ParentID", DBNull.Value);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Division department)
        {
            // Проверить, есть ли пользователи, относящиеся к текущему подразделению
            CheckUsers(department);

            // Обновить связи родительского подразделения
            UpdateParentDepartments( department);

            // Удалить связи с совещательными залами
            _divisionHollWriter.RemoveDepartmentMeetingRooms(department);

            // Удалить текущее подразделение
            RemoveDepartment(department);
        }

        public void RemoveDepartment(Division department)
        {
            string deleteQuery = "DELETE FROM department WHERE id = @DepartmentID";
            using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, _connection))
            {
                deleteCommand.Parameters.AddWithValue("@DepartmentID", department.ID);
                deleteCommand.ExecuteNonQuery();
            }
        }

        public void Update(Division department)
        {
            string query = "UPDATE department SET name = @Name, parent_id = @ParentID WHERE id = @DepartmentID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@DepartmentID", department.ID);
                command.Parameters.AddWithValue("@Name", department.Name);
                command.Parameters.AddWithValue("@ParentID", department.ParentID);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateParentDepartments(Division department)
        {
            throw new NotImplementedException();
        }
    }
}
