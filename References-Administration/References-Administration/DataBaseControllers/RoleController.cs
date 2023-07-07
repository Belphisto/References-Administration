using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class RoleController
    {
        public static List<string> GetRoles(NpgsqlConnection connection)
        {
            List<string> roles = new List<string>();
            string query = "SELECT * FROM role";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(reader["name"].ToString());
                    }
                }
            }
            return roles;
        }

        public static void Create(NpgsqlConnection connection, string role)
        {
            string query = "INSERT INTO role (name) VALUES (@Name)";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", role);
                command.ExecuteNonQuery();
            }
        }

        public static void Update(NpgsqlConnection connection, string lastrole, string newRole)
        {
            string query = "UPDATE role SET name = @newRole, WHERE name = @lastRole";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@newRole", newRole);
                command.Parameters.AddWithValue("@lastRole", lastrole);
                command.ExecuteNonQuery();
            }
        }

        public static void Delete(NpgsqlConnection connection, string role)
        {
            string query = "DELETE FROM role WHERE name = @Role";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Role", role);
                command.ExecuteNonQuery();
            }
        }

        public static int GetID(NpgsqlConnection connection, string role)
        {
            int id = 0;
            string query = "SELECT id FROM role WHERE name = @Role";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Role", role);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = (int)reader["id"];
                    }
                }
            }
            return id;
        }

        public static void AddRoleToClient(NpgsqlConnection connection, string role, Client client)
        {
            int id_role = GetID(connection, role);
            string query = "INSERT INTO userrole (userid, roleid) VALUES (@IdClient, @IdRole)";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdClient", client.ID);
                command.Parameters.AddWithValue("@IdRole", id_role);
                command.ExecuteNonQuery();
            }
        }

        public static void RemoveRoleFromClient(NpgsqlConnection connection, string role, Client client)
        {
            int id_role = GetID(connection, role);
            string query = "DELETE FROM userrole WHERE userid = @IdClient AND roleid = @IdRole";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdClient", client.ID);
                command.Parameters.AddWithValue("@IdRole", id_role);
                command.ExecuteNonQuery();
            }
        }

        public static List<string> GetUserRoles(NpgsqlConnection connection, Client client)
        {
            List<string> roles = new List<string>();
            string query = "SELECT r.name FROM role r JOIN userrole ur ON ur.roleid = r.id JOIN client c ON c.id = ur.userid WHERE c.id = @ClientID";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClientID", client.ID);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(reader["name"].ToString());
                    }
                }
            }
            return roles;
        }

        public static List<string> GetMissingRoles(NpgsqlConnection connection, Client client)
        {
            List<string> roles = new List<string>();
            string query = "SELECT r.name FROM role r WHERE r.id NOT IN( SELECT ur.roleid FROM userrole ur WHERE ur.userid = @ClientID);";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClientID", client.ID);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(reader["name"].ToString());
                    }
                }
            }
            return roles;
        }
    }
}
