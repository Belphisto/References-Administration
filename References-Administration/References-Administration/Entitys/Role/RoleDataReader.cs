using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class RoleDataReader : IRoleDataReader
    {
        private readonly NpgsqlConnection _connection;

        public RoleDataReader(DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public int GetID(string role)
        {
            int id = 0;
            string query = "SELECT id FROM role WHERE name = @Role";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
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

        public List<string> GetMissingRoles(User client)
        {
            List<string> roles = new List<string>();
            string query = "SELECT r.name FROM role r WHERE r.id NOT IN( SELECT ur.roleid FROM userrole ur WHERE ur.userid = @ClientID);";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
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

        public List<string> GetRoles()
        {
            List<string> roles = new List<string>();
            string query = "SELECT * FROM role";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
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

        public List<int> GetUserIds(string role)
        {
            var ids = new List<int>();
            string query = "SELECT c.id FROM client c JOIN userrole ur ON c.id = ur.userid JOIN role r ON ur.roleid = r.id WHERE r.name = @Role;";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Role", role);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ids.Add((int)reader["id"]);
                    }
                }
            }
            return ids;
        }

        public List<string> GetUserRoles(User client)
        {
            List<string> roles = new List<string>();
            string query = "SELECT r.name FROM role r JOIN userrole ur ON ur.roleid = r.id JOIN client c ON c.id = ur.userid WHERE c.id = @ClientID";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
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
