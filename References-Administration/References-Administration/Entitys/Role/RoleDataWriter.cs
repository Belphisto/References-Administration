using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class RoleDataWriter : IRoleDataWriter
    {
        private readonly NpgsqlConnection _connection;

        public RoleDataWriter(DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public void AddRoleToClient(int roleId, User client)
        {
            string query = "INSERT INTO userrole (userid, roleid) VALUES (@IdClient, @IdRole)";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@IdClient", client.ID);
                command.Parameters.AddWithValue("@IdRole", roleId);
                command.ExecuteNonQuery();
            }
        }

        public void Create(string role)
        {
            string query = "INSERT INTO role (name) VALUES (@Name)";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Name", role);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(string role)
        {
            string query = "DELETE FROM role WHERE name = @Role";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Role", role);
                command.ExecuteNonQuery();
            }
        }

        public void RemoveRoleFromClient(int roleId, User client)
        {
            string query = "DELETE FROM userrole WHERE userid = @IdClient AND roleid = @IdRole";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@IdClient", client.ID);
                command.Parameters.AddWithValue("@IdRole", roleId);
                command.ExecuteNonQuery();
            }
        }

        public void Update(string lastrole, string newRole)
        {
            string query = "UPDATE role SET name = @newRole, WHERE name = @lastRole";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@newRole", newRole);
                command.Parameters.AddWithValue("@lastRole", lastrole);
                command.ExecuteNonQuery();
            }
        }
    }
}
