using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace References_Administration
{
    public class UserDataWriter : IUserDataWriter
    {
        private readonly NpgsqlConnection _connection;

        public UserDataWriter(DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public void Create(User client)
        {
            string query = "INSERT INTO client (fullname, login, password_hash, id_department, email) VALUES (@Fullname, @Login, @Password_hash, @Id_department, @Email)";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Fullname", client.FullName);
                command.Parameters.AddWithValue("@Login", client.Login);
                command.Parameters.AddWithValue("@Password_hash", client.PasswordHash);
                command.Parameters.AddWithValue("@Id_department", client.DepartmentID);
                command.Parameters.AddWithValue("@Email", client.EmailAddress);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(User client)
        {
            // Удалить текущего пользователя из базы данных
            string deleteQuery = "DELETE FROM client WHERE id = @ClientID";
            using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, _connection))
            {
                deleteCommand.Parameters.AddWithValue("@ClientID", client.ID);
                deleteCommand.ExecuteNonQuery();
            }
        }

        public void Update(User client)
        {
            string query = "UPDATE client SET fullname = @Fullname, password_hash = @Password_hash, id_department = @Department_ID WHERE id = @ClientID";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@ClientID", client.ID);
                command.Parameters.AddWithValue("@Fullname", client.FullName);
                command.Parameters.AddWithValue("@Password_hash", client.PasswordHash);
                command.Parameters.AddWithValue("@Department_ID", client.DepartmentID);
                command.ExecuteNonQuery();
            }
        }
    }
}
